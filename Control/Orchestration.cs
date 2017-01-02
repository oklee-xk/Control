using Remote;
using XInputDotNetPure;
using System.Timers;
using System.Threading.Tasks;
using System;

namespace Control {
    static class Orchestration {
        static LGTV tv = new LGTV(Constants.IP);
        static Pc pc = new Pc();
        const bool TV_ENABLE = true;
        const bool PC_ENABLE = true;
        const float MAX_MOUSE_VEL = 80; // pixels/frame
        static bool ENABLE = true;
        static bool enableBtnIsPressed = false;
        static bool leftClickPressed = false;
        static bool rightClickPressed = false;

        public static void Start() {
            writeInfo();

            Timer connectionTimer = new Timer();
            connectionTimer.Elapsed += new ElapsedEventHandler(ConnectTv);
            connectionTimer.Interval = 3000;
            connectionTimer.Enabled = TV_ENABLE;

            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 17;
            timer.Enabled = true;
        }

        public static void writeInfo() {
            Console.WriteLine("TV is {0}", TV_ENABLE ? "enable" : "disable");
            Console.WriteLine("PC is {0}", TV_ENABLE ? "enable" : "disable");
        }

        private static void ConnectTv(object source, ElapsedEventArgs e) {
            if (tv.isPaired) {
                Console.WriteLine("Tv is Paired");
                ((Timer)source).Enabled = false;
                return;
            }

            if (!tv.isConnected) {
                Task<bool> connection = tv.getConnection().connect();
                connection.Wait();
            }

            if (tv.isConnected && !tv.isPaired && !tv.isPromptVisible) {
                tv.pair();
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            GamePadState reader = GamePad.GetState(PlayerIndex.One);
            //General Stuff
            if (!enableBtnIsPressed &&
                ButtonState.Pressed == reader.Buttons.Start &&
                ButtonState.Pressed == reader.Buttons.Back) {
                ENABLE = !ENABLE;
                enableBtnIsPressed = true;
            }

            if (enableBtnIsPressed &&
                ButtonState.Released == reader.Buttons.Start &&
                ButtonState.Released == reader.Buttons.Back) {
                enableBtnIsPressed = false;
            }

            if (enableBtnIsPressed || !ENABLE) return;

            //PC Stuff
            if (PC_ENABLE) {
                if (ButtonState.Pressed == reader.Buttons.Back) {
                    pc.sleep();
                }

                if (!leftClickPressed && ButtonState.Pressed == reader.Buttons.A) {
                    leftClickPressed = true;
                    pc.leftClickDown();
                }

                if (leftClickPressed && ButtonState.Released == reader.Buttons.A) {
                    leftClickPressed = false;
                    pc.leftClickUp();
                }

                if (!rightClickPressed && ButtonState.Pressed == reader.Buttons.X) {
                    rightClickPressed = true;
                    pc.rightClickDown();
                }

                if (rightClickPressed && ButtonState.Released == reader.Buttons.X) {
                    rightClickPressed = false;
                    pc.rightClickUp();
                }

                //mouse movements
                double x = reader.ThumbSticks.Left.X;
                double y = reader.ThumbSticks.Left.Y;
                x = Math.Sign(x) * Math.Abs(Math.Pow(x, 3) *  MAX_MOUSE_VEL);
                y = Math.Sign(y) * Math.Abs(Math.Pow(y, 3) * MAX_MOUSE_VEL);
                x =  Math.Ceiling(x);
                y = -Math.Ceiling(y);

                pc.moveCursor((int) x, (int) y, true);
            }


            //TV Stuff
            if (TV_ENABLE && reader.IsConnected && tv.isPaired) {
                if (ButtonState.Pressed == reader.Buttons.Back) {
                    tv.off();
                }

                if (ButtonState.Pressed == reader.Buttons.Y) {
                    Console.WriteLine("Volume Up");
                    tv.volumeUp();
                }

                if (ButtonState.Pressed == reader.Buttons.B) {
                    Console.WriteLine("Volume Down");
                    tv.volumeDown();
                }
            }
        }
    }
}
