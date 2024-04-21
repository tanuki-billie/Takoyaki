using System;

namespace Takoyaki.Core.Display;

public class Chip8Display
{
    public byte[] Display { get; private set; } = new byte[0x400];
    public DisplayMode DisplayMode { get; private set; } = DisplayMode.Lores;
    public bool Dirty { get; private set; } = false;

    // 00E0 - clear display
    public void ClearDisplay()
    {
        Dirty = true;
        for (var i = 0; i < Display.Length; i++)
        {
            Display[i] = 0;
        }
    }

    // DXYN - draw sprite
    public byte DrawSpriteLores(byte[] sprite, int x, int y, int rows)
    {
        // Dirties screen
        Dirty = true;

        // Ensure coordinates are within the bounds of the screen
        x &= 63;
        y &= 31;

        byte setFlag = 0;

        return setFlag;
    }
}

public enum DisplayMode
{
    None,
    Lores,
    Hires,
}