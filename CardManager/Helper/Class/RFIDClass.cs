using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Bouwa.Helper.Class
{
    /// <summary>
    /// 对RFID刷卡的所有操作封装，目前只支持TYPEA类型卡
    /// </summary>
    public class RFIDClass
    {
        private static System.Text.Encoding _TextCode = System.Text.Encoding.Default; //转换的编码格式

        /// <summary>
        /// 转换时的编码格式
        /// </summary>
        public static System.Text.Encoding TextCode
        {
            get { return RFIDClass._TextCode; }
            set { RFIDClass._TextCode = value; }
        }
        #region  外部调用方法

        /// <summary>
        /// 读取RFID 某扇区的 某一块区域的数据
        /// </summary>
        /// <param name="key">扇区密码密码</param>
        /// <param name="cSector">扇区的下标，如：3</param>
        /// <returns>返回读取的值，下标0为RFID卡号，下标1-3为该扇区下的0~2的三块地方存放的对应值，下标4为验证结果</returns>
        public static string[] ReadCardAndReturnStatus(string key, int cSector)
        {
            string[] mary = new string[5];

            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = ConvertPassWord(key); //转换密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY;

            //指定区号
            myareano = (byte)cSector;//指定为第 cSector 区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证
            //读取值并返回状态
            status = piccreadex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);

            //根据对应的值跟状态进行数据操作
            mary[0] =  BitConverter.ToString(mypiccserial); //保存卡号
            //循环把对应块的值取出来
            mary[1] = TextCode.GetString(mypiccdata, 0, 16).ToString().Replace("\0", "");
            mary[2] = TextCode.GetString(mypiccdata, 16, 16).ToString().Replace("\0", "");
            mary[3] = TextCode.GetString(mypiccdata, 32, 16).ToString().Replace("\0", "");
            mary[4] = status.ToString(); //保存状态
            return mary;
            
       }

        /// <summary>
        /// 向 某扇区的 某一块区域写入数据
        /// </summary>
        /// <param name="CarID">RFID卡号(为null就不进行验证)，如：4C-5R-7Y-3E</param>
        /// <param name="key">扇区密码密码</param>
        /// <param name="cSector">扇区的下标，如：3</param>
        /// <param name="cBlock">块的下标(0-2)，如：0</param>
        /// <param name="value">写入的字符串数组，对应到对应写入0~2的块</param>
        /// <returns>返回写入结果，0成功， 1失败 ， 2不是同一张卡 ， 3字符串太长等等</returns>
        public static int WriterCardAndReturnStatus(string CarID, string key, int cSector, int cBlock, string value)
        {
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] mypicckey = ConvertPassWord(key); //转换密码
            byte[] mypiccserial = new byte[4];//卡序列号
            byte[] mypiccdata = new byte[48]; //卡数据缓冲
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY;

            //指定区号
            myareano = (byte)cSector;//指定为第 cSector 区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证
            //获得写入的值，汉字长度小于8
            Byte[] pBlockWriteData = TextCode.GetBytes(value.Trim());
            //先读取值并返回状态
            status = piccreadex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
            if (string.IsNullOrEmpty(CarID) == false && CarID != BitConverter.ToString(mypiccserial))
            {
                return 2; //返回不是同一张卡
            }
            else if (cBlock>2)
            {
                return 1; //超过写入块，直接返回失败
            }
            else if (pBlockWriteData.Length > 16)
            {
                return 3;//字符串太长
            }
            int j = 0; //循环变量
            //指定卡数据
            for (byte i = 0; i < mypiccdata.Length; i++)
            {
                if (i >= (cBlock * 16) && i < ((cBlock+1) * 16))
                {
                    if (j < pBlockWriteData.Length)
                    {
                        mypiccdata[i] = pBlockWriteData[j];
                    }
                    else {
                        mypiccdata[i] = 00;
                    }
                    j++;
                }
            }
            //执行写入
            status = piccwriteex(myctrlword, mypiccserial, myareano, authmode, mypicckey, mypiccdata);
            //处理返回函数
            return status;
        }

        /// <summary>
        /// 修改某扇区的密码
        /// </summary>
        /// <param name="CarID">RFID卡号(为null就不进行验证)，如：4C-5R-7Y-3E</param>
        /// <param name="cSector">扇区的下标，如：3</param>
        /// <param name="oldkey">老密码</param>
        /// <param name="newkey">新的密码</param>
        /// <returns>下标0返回状态，下标1返回卡号（状态包括：2不是同一张卡 等等）</returns>
        public static string[] UpdateCardPassWordAndReturnStatus(string CarID, int cSector, string oldkey, string newkey)
        {
            string[] mary=new string[2];
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] piccoldkey = ConvertPassWord(oldkey);//老密码存放处
            byte[] mypiccserial = new byte[4];//卡序列号
            //指定新密码,注意：指定新密码时一定要记住，否则有可能找不回密码，导致该卡报废。
            byte[] piccnewkey = ConvertPassWord(newkey); //新密码存放处

           
            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = 0;

            //指定区号
            myareano = (byte)cSector;//指定为第 cSector 区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证

            //判断是否需要验证卡号
            if (string.IsNullOrEmpty(CarID) == false) {
                byte[] mypiccdata = new byte[48]; //卡数据缓冲
                //先读取值并返回状态
                piccreadex((BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY), mypiccserial, myareano, authmode, piccoldkey, mypiccdata);
                if (CarID != BitConverter.ToString(mypiccserial))
                {
                    mary[0] = "2"; //返回不是同一张卡
                    mary[1] = BitConverter.ToString(mypiccserial);
                    return mary;
                }
            }
            status = piccchangesinglekey(myctrlword, mypiccserial, myareano, authmode, piccoldkey, piccnewkey);
            mary[0] = status.ToString();
            mary[1] = BitConverter.ToString(mypiccserial);
            return mary;
        }

        /// <summary>
        /// 修改某扇区的密码为初始密码
        /// </summary>
        /// <param name="CarID">RFID卡号(为null就不进行验证)，如：4C-5R-7Y-3E</param>
        /// <param name="cSector">扇区的下标，如：3</param>
        /// <param name="oldkey">老密码</param>
        /// <returns>下标0返回状态，下标1返回卡号（状态包括：2不是同一张卡 等等）</returns>
        public static string[] UpdateCardPassWordAndReturnStatus(string CarID, int cSector, string oldkey)
        {
            string[] mary = new string[2];
            byte status;//存放返回值
            byte myareano;//区号
            byte authmode;//密码类型，用A密码或B密码
            byte myctrlword;//控制字
            byte[] piccoldkey = ConvertPassWord(oldkey);//老密码存放处
            byte[] mypiccserial = new byte[4];//卡序列号
            //指定新密码,注意：指定新密码时一定要记住，否则有可能找不回密码，导致该卡报废。
            byte[] piccnewkey = ConvertPassWord(""); //新密码存放处


            //控制字指定,控制字的含义请查看本公司网站提供的动态库说明
            myctrlword = 0;

            //指定区号
            myareano = (byte)cSector;//指定为第 cSector 区
            //批定密码模式
            authmode = 1;//大于0表示用A密码认证，推荐用A密码认证

            //判断是否需要验证卡号
            if (string.IsNullOrEmpty(CarID) == false)
            {
                byte[] mypiccdata = new byte[48]; //卡数据缓冲
                //先读取值并返回状态
                piccreadex((BLOCK0_EN + BLOCK1_EN + BLOCK2_EN + EXTERNKEY), mypiccserial, myareano, authmode, piccoldkey, mypiccdata);
                if (CarID != BitConverter.ToString(mypiccserial))
                {
                    mary[0] = "2"; //返回不是同一张卡
                    mary[1] = BitConverter.ToString(mypiccserial);
                    return mary;
                }
            }
            status = piccchangesinglekey(myctrlword, mypiccserial, myareano, authmode, piccoldkey, piccnewkey);
            mary[0] = status.ToString();
            mary[1] = BitConverter.ToString(mypiccserial);
            return mary;
        }

        /// <summary>
        /// 发送显示内容到读卡器
        /// </summary>
        /// <param name="ContentText">要发送的文本内容</param>
        /// <returns>返回状态结果</returns>
        public static int SendContentToCardReader(string ContentText) {
            return lcddispfull(ContentText);
        }

        /// <summary>
        /// 让IC读卡设备发出声音
        /// </summary>
        /// <param name="Millisecond">毫秒数</param>
        public static void IssueSound(int Millisecond)
        {
            pcdbeep((byte)Millisecond);
        }

        /// <summary>
        /// 根据状态返回对应的错误信息
        /// </summary>
        /// <param name="status">状态值</param>
        /// <returns>返回对应的错误信息值</returns>
        public static string ConvertMeassByStatus(int status) {
            //处理返回函数
            switch (status)
            {
                case 0:
                   return "操作成功！";
                case 2:
                   return "不是同一张卡，请重新读卡！";   
                case 8:
                    return "请将卡放在感应区！";
                case 9:
                    return "读序列码错误！";
                case 10:
                    return "选卡错误！";
                case 11:
                    return "装载密码错误！";
                case 12:
                    return "密码认证错误！";
                case 13:
                    return "读卡错误！";
                case 14:
                    return "写卡错误！";
                case 21:
                    return "没有动态库！";
                case 22:
                    return "动态库或驱动程序异常！";
                case 23:
                    return "不能正确启动读卡设备，请检查读卡器连接及驱动程序是否安装！";
                case 24:
                    return "操作超时，一般是动态库没有反映！";
                case 25:
                    return "发送字数不够！";
                case 26:
                    return "发送的CRC错！";
                case 27:
                    return "接收的字数不够！";
                case 28:
                    return "接收的CRC错！";
                case 99: //自己添加的 
                    return "远程服务器传输不正确，请联系管理员！";
                default:
                    return "卡已损坏，请更换卡！";
            }

        }

        /// <summary>
        /// 进行密码的转换
        /// </summary>
        /// <param name="key">要转换成密码的字符串</param>
        /// <returns>返回转换后的byte数组</returns>
        public static byte[] ConvertPassWord(string key)
        { 
            byte[] password=new byte[6];
            try
            {
                //如果不传送的话就取默认密码
                if (key == null || string.IsNullOrEmpty(key))
                {

                    password = new Byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                }
                else {
                    password = System.Text.Encoding.ASCII.GetBytes(key); //密码存放处
                }
                return password;
            }
            catch
            {
                return password;
            }
        }

        /// <summary>
        /// 进行密码的转换
        /// </summary>
        /// <param name="password">要转换成密码的byte数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string ConvertPassWord(byte[] password)
        {
            //先取默认密码
            return "FFFFFFFFFFFF";
        }


        #endregion

        #region 所有内部操作方法存放处


        /// <summary>
        /// 必需的设计器变量。
        //常量定义
        private const byte BLOCK0_EN = 0x01;//操作第0块
        private const byte BLOCK1_EN = 0x02;//操作第1块
        private const byte BLOCK2_EN = 0x04;//操作第2块
        private const byte NEEDSERIAL = 0x08;//仅对指定序列号的卡操作
        private const byte EXTERNKEY = 0x10;
        private const byte NEEDHALT = 0x20;//读卡或写卡后顺便休眠该卡，休眠后，卡必须拿离开感应区，再放回感应区，才能进行第二次操作。


        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //外部函数声明：让设备发出声响
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep")]
        private static extern byte pcdbeep(ulong xms);//xms单位为毫秒 

        //------------------------------------------------------------------------------------------------------------------------------------------------------    
        //读取设备编号，可做为软件加密狗用,也可以根据此编号在公司网站上查询保修期限
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdgetdevicenumber")]
        private static extern byte pcdgetdevicenumber(byte[] devicenumber);//devicenumber用于返回编号 


        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //轻松读卡
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccreadex")]
        private static extern byte piccreadex(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] picckey, byte[] piccdata0_2);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //picckey：指定卡密码，6个字节，卡出厂时的初始密码为6个0xff
        //piccdata0_2：用于返回卡该区第0块到第2块的数据，共48个字节.


        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //轻松写卡
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccwriteex")]
        private static extern byte piccwriteex(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] picckey, byte[] piccdata0_2);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //picckey：指定卡密码，6个字节，卡出厂时的初始密码为6个0xff
        //piccdata0_2：用于返回卡该区第0块到第2块的数据，共48个字节.


        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //修改卡单区的密码
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccchangesinglekey")]
        private static extern byte piccchangesinglekey(byte ctrlword, byte[] serial, byte area, byte keyA1B0, byte[] piccoldkey, byte[] piccnewkey);
        //参数：说明
        //ctrlword：控制字
        //serial：卡序列号数组，用于指定或返回卡序列号
        //area：指定读卡区号
        //keyA1B0：指定用A或B密码认证,一般是用A密码，只有特殊用途下才用B密码，在这不做详细解释。
        //piccoldkey：//旧密码
        //piccnewkey：//新密码.


        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //发送显示内容到读卡器
        [DllImport("OUR_MIFARE.dll", EntryPoint = "lcddispfull")]
        private static extern byte lcddispfull(string lcdstr);
        //参数：说明
        //lcdstr：显示内容


        #endregion

    }
}
