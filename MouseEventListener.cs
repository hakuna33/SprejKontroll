using System;
using System.Windows.Forms;
using SharpDX.Multimedia;
using SharpDX.RawInput;
using System.Threading;

public static class MouseEventListener
{
    private static bool MouseButton1Down = false;
    private static bool MouseButton2Down = false;
    private static Action<bool, bool> OnEvent;
    
    public static void StartMouseEventListener(Action<bool, bool> onMouseEvent)
    {
        var messagePump = new Thread(RunMessagePump) { Name = "ManualMessagePump" };
        messagePump.Start();
        OnEvent = onMouseEvent;
    }
    
    private static void RunMessagePump()
    {
        var messageHandler = new MessageHandler();
        Device.RegisterDevice(UsagePage.Generic, UsageId.GenericMouse, DeviceFlags.InputSink, messageHandler.Handle);
        Device.MouseInput += ProcessMouseInput;
        Application.Run();
    }

    private static void ProcessMouseInput(object sender, MouseInputEventArgs args)
    {
        switch (args.ButtonFlags)
        {
            case MouseButtonFlags.Button1Down:
                MouseButton1Down = true;
                break;
            case MouseButtonFlags.Button1Up:
                MouseButton1Down = false;
                break;
            case MouseButtonFlags.Button2Down:
                MouseButton2Down = true;
                break;
            case MouseButtonFlags.Button2Up:
                MouseButton2Down = false;
                break;
        }

        OnEvent?.Invoke(MouseButton1Down, MouseButton2Down);
    }
}

internal class MessageHandler : NativeWindow
{
    public MessageHandler()
    {
        CreateHandle(new CreateParams());
    }
}