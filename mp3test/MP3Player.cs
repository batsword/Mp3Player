using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace mp3test
{
    

    namespace 使用API播放音乐
    {
        public class MP3Player
        {
            /// <summary>   
            /// 文件地址   
            /// </summary>   
            public string FilePath;

            /// <summary>   
            /// 播放   
            /// </summary>   
            public void Play()
            {
                mciSendString("close all", "", 0, 0);
                mciSendString("open " + FilePath + " alias media", "", 0, 0);
                mciSendString("play media", "", 0, 0);
            }

            /// <summary>   
            /// 暂停   
            /// </summary>   
            public void Pause()
            {
                mciSendString("pause media", "", 0, 0);
            }

            /// <summary>   
            /// 停止   
            /// </summary>   
            public void Stop()
            {
                mciSendString("close media", "", 0, 0);
            }

            /// <summary>   
            /// API函数   
            /// </summary>   
            [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
            private static extern int mciSendString(
             string lpstrCommand,
             string lpstrReturnString,
             int uReturnLength,
             int hwndCallback
            );

            [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume", CharSet = CharSet.Auto)]
            public static extern int waveOutSetVolume(uint deviceID, uint Volume);
            public int Volume                   // 音量 0 ～ 1000
            {
                get;
                set;
                //get
                //{
                //    errCode = mciSendString("status music volume", buff, buff.Length, 0);
                //    int p = buff.IndexOf('\0');
                //    string s = buff.Substring(0, p);
                //    if (string.IsNullOrEmpty(s)) return 0;
                //    return int.Parse(s);
                //}
                //set
                //{
                //    errCode = mciSendString("setaudio music volume to " + value, buff, buff.Length, 0);
                //}
            }

            /// <summary>
            /// mp3.LeftVolume = 0x0000ffff;
            /// mp3.RightVolume = 0xffff0000;
            /// </summary>
            public uint LeftRightVolume         // 分别控制左右声道的音量
            {
                set
                {
                    waveOutSetVolume(0, value);  // 0xffffffff，高2字节控制右声道，低2字节控制左声道。
                }
            }

            public void setLeftRightVolume(uint volume)
            {
                waveOutSetVolume(0, volume);
            }

        }
    }
}
