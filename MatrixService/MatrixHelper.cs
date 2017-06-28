using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MatrixService
{
    /// <summary>
    /// 指令发送帮助类
    /// </summary>
    public class MatrixHelper
    {
        /// <summary>
        /// RGB
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="str"></param>
        public void sendRGB(SerialPort sp, string str)
        {
            try
            {
                if (!(sp.IsOpen))
                {
                    sp.Open();
                }

                sp.WriteLine(str);
            }
            catch
            {
                throw new Exception("端口未连接！");
            }
            finally
            {
                //sp.Close();
            }
        }

        /// <summary>
        /// CHAR
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="chr"></param>
        public void sendCHAR(SerialPort sp, char[] chr)
        {
            try
            {
                if (!(sp.IsOpen))
                {
                    sp.Open();
                }

                sp.Write(chr, 0, 7);
            }
            catch
            {
                throw new Exception("端口未连接！");
            }
            finally
            {
                //sp.Close();
            }
        }

        /// <summary>
        /// HEX
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="str"></param>
        public void sendHEX(SerialPort sp, byte[] str)
        {
            try
            {
                if (!(sp.IsOpen))
                {
                    sp.Open();
                }

                sp.Write(str, 0, 2);
            }
            catch
            {
                throw new Exception("端口未连接！");
            }
            finally
            {
                //sp.Close();
            }
        }

        /// <summary>
        /// Audio
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="str"></param>
        public void sendAudio(SerialPort sp, string str)
        {
            try
            {
                if (!(sp.IsOpen))
                {
                    sp.Open();
                }

                sp.WriteLine(str);
            }
            catch
            {
                throw new Exception("端口未连接！");
            }
            finally
            {
                //sp.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="Command"></param>
        public void sendCommand(SerialPort sp, char[] Command)
        {

            try
            {
                if (!(sp.IsOpen))
                {
                    sp.Open();
                }

                sp.Write(Command, 0, Command.Length);
            }
            catch
            {
                throw new Exception("端口未连接！");
            }
            finally
            {
                //sp.Close();
            }
        }
    }
}
