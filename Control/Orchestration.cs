using Remote;
using XInputDotNetPure;
using System.Timers;
using System.Threading.Tasks;
using System;

namespace Control {
    static class Orchestration {
        static LGTV tv = new LGTV(Constants.IP);
        static Pc pc = new Pc();
        static Timer connectionTimer = new Timer();
        static Timer timer = new Timer();
        const bool TV_ENABLE = true;
        const bool PC_ENABLE = true;
        const float MAX_MOUSE_VEL = 20; // pixels/frame
        static bool ENABLE = true;
        static bool enableBtnIsPressed = false;
        static bool leftClickPressed = false;
        static bool leftStickPressed = false;
        static bool rightClickPressed = false;
        static bool leftShoulderPressed = false;
        static bool rightShoulderPressed = false;
        static bool turnOffBtnPressed = false;

        public static void Start() {
            writeInfo();

            connectionTimer.Elapsed += new ElapsedEventHandler(ConnectTv);
            connectionTimer.Interval = 3000;
            connectionTimer.Enabled = TV_ENABLE;

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 17;
            timer.Enabled = true;
        }

        public static void writeInfo() {
            Console.WriteLine("TV is {0}", TV_ENABLE ? "enable" : "disable");
            Console.WriteLine("PC is {0}", TV_ENABLE ? "enable" : "disable");
        }

        public static bool ImInBrowser() {
            //TODO
            return false;
        }

        private static void ConnectTv(object source, ElapsedEventArgs e) {
            if (tv.isPaired) {
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
                if (!turnOffBtnPressed && ButtonState.Pressed == reader.Buttons.Back) {
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

                if (!leftStickPressed && ButtonState.Pressed == reader.Buttons.LeftStick) {
                    leftStickPressed = true;
                    pc.leftClickDown();
                }

                if (leftStickPressed && ButtonState.Released == reader.Buttons.LeftStick) {
                    leftStickPressed = false;
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

                if (!leftShoulderPressed && ButtonState.Pressed == reader.Buttons.LeftShoulder) {
                    leftShoulderPressed = true;
                    System.Diagnostics.Process.Start("http://youtube.com");
                }

                if (leftShoulderPressed && ButtonState.Released == reader.Buttons.LeftShoulder) {
                    leftShoulderPressed = false;
                }

                if (!rightShoulderPressed && ButtonState.Pressed == reader.Buttons.RightShoulder) {
                    rightShoulderPressed = true;
                    System.Diagnostics.Process.Start("https://www.netflix.com/browse");
                }

                if (rightShoulderPressed && ButtonState.Released == reader.Buttons.RightShoulder) {
                    rightShoulderPressed = false;
                }

                double rightStickY = reader.ThumbSticks.Right.Y;
                double rightStickX = reader.ThumbSticks.Right.X;
                if (rightStickY != 0) pc.wheel(Math.Sign(rightStickY));
                if (rightStickX != 0) pc.hWheel(Math.Sign(rightStickX));


                //mouse movements
                double leftStickX = reader.ThumbSticks.Left.X;
                double leftStickY = reader.ThumbSticks.Left.Y;
                leftStickX *= MAX_MOUSE_VEL;
                leftStickY *= -MAX_MOUSE_VEL;
                //leftStickX = Math.Sign(leftStickX) * Math.Abs(Math.Pow(leftStickX, 2) *  MAX_MOUSE_VEL);
                //leftStickY = Math.Sign(leftStickY) * Math.Abs(Math.Pow(leftStickY, 2) * MAX_MOUSE_VEL);
                //leftStickX =  Math.Ceiling(leftStickX);
                //leftStickY = -Math.Ceiling(leftStickY);

                pc.moveCursor((int) leftStickX, (int) leftStickY, true);
            }


            //TV Stuff
            if (TV_ENABLE) connectionTimer.Enabled = !tv.isConnected;

            if (TV_ENABLE && reader.IsConnected && tv.isPaired) {
                if (!turnOffBtnPressed && ButtonState.Pressed == reader.Buttons.Back) {
                    tv.off();
                }

                if (ButtonState.Pressed == reader.Buttons.Y) {
                    tv.volumeUp();
                }

                if (ButtonState.Pressed == reader.Buttons.B) {
                    tv.volumeDown();
                }
            }

            //conditionals for the tv off btn.
            if (!turnOffBtnPressed && ButtonState.Pressed == reader.Buttons.Back) {
                turnOffBtnPressed = true;
            }

            if (turnOffBtnPressed && ButtonState.Released == reader.Buttons.Back) {
                turnOffBtnPressed = false;
            }
        }
    }
}
