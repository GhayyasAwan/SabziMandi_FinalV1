using System;
using System.Drawing;
using System.Windows.Forms;

public class SmoothScrollingLabel : Label
{
    private Timer scrollTimer;
    private float scrollPosition;
    private string fullText;
    private Bitmap textBitmap;
    private Graphics textGraphics;

    public SmoothScrollingLabel()
    {
        this.Dock = DockStyle.Top;
        this.AutoSize = false;
        this.TextAlign = ContentAlignment.MiddleLeft;
        this.RightToLeft = RightToLeft.Yes;
        this.DoubleBuffered = true;

        scrollTimer = new Timer { Interval = 16 }; // ~60fps
        scrollTimer.Tick += ScrollTimer_Tick;
    }

    public new string Text
    {
        get => fullText;
        set
        {
            fullText = value;
            scrollPosition = 0;
            PrepareTextBitmap();
            scrollTimer.Start();
        }
    }

    private void PrepareTextBitmap()
    {
        textBitmap?.Dispose();
        textGraphics?.Dispose();

        SizeF textSize = TextRenderer.MeasureText(fullText, this.Font);
        int bitmapWidth = (int)textSize.Width + this.Width * 2;
        textBitmap = new Bitmap(bitmapWidth, this.Height);
        textGraphics = Graphics.FromImage(textBitmap);

        // Draw text on bitmap
        textGraphics.Clear(this.BackColor);
        TextRenderer.DrawText(textGraphics, fullText, this.Font,
                            new Point(this.Width, (this.Height - (int)textSize.Height) / 2),
                            this.ForeColor);
    }

    private void ScrollTimer_Tick(object sender, EventArgs e)
    {
        scrollPosition += 0.5f; // Adjust speed here

        if (scrollPosition > textBitmap.Width - this.Width)
        {
            scrollPosition = 0;
        }

        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (textBitmap != null)
        {
            e.Graphics.DrawImage(textBitmap,
                               new Rectangle(0, 0, this.Width, this.Height),
                               new Rectangle((int)scrollPosition, 0, this.Width, this.Height),
                               GraphicsUnit.Pixel);
        }
        else
        {
            base.OnPaint(e);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            scrollTimer?.Dispose();
            textBitmap?.Dispose();
            textGraphics?.Dispose();
        }
        base.Dispose(disposing);
    }
}



public class ScrollingLabel : Label
{
    private Timer scrollTimer;
    private int scrollPosition;
    private string fullText;

    public ScrollingLabel()
    {
        // Setup label properties
        this.Dock = DockStyle.Top;
        this.AutoSize = false;
        this.TextAlign = ContentAlignment.MiddleLeft;
        this.RightToLeft = RightToLeft.Yes; // Important for Urdu

        // Initialize scrolling
        scrollTimer = new Timer { Interval = 30 }; // Adjust speed as needed
        scrollTimer.Tick += ScrollTimer_Tick;
    }

    public new string Text
    {
        get => fullText;
        set
        {
            fullText = value;
            scrollPosition = 0;
            base.Text = fullText;
            scrollTimer.Start();
        }
    }

    private void ScrollTimer_Tick(object sender, EventArgs e)
    {
        scrollPosition++;

        // When text scrolls completely left, reset position
        if (scrollPosition > this.Width + GetTextWidth(fullText))
        {
            scrollPosition = 0;
        }

        // Create scrolling effect by adjusting text padding
        base.Text = fullText.PadLeft(scrollPosition + fullText.Length);

        this.Invalidate();
    }

    private int GetTextWidth(string text)
    {
        using (Graphics g = this.CreateGraphics())
        {
            return (int)g.MeasureString(text, this.Font).Width;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            scrollTimer?.Dispose();
        }
        base.Dispose(disposing);
    }
}



public class UrduScrollingLabel : Label
{
    private Timer scrollTimer;
    private float scrollPosition;
    private string fullText;
    private Bitmap textBitmap;
    private Graphics textGraphics;
    private int textWidth;

    public UrduScrollingLabel()
    {
        // Basic label setup
        this.Dock = DockStyle.Top;
        this.AutoSize = false;
        this.Height = 40; // Set your preferred height
        this.TextAlign = ContentAlignment.MiddleRight; // Right align for Urdu
        this.RightToLeft = RightToLeft.Yes; // Important for proper Urdu rendering
        this.DoubleBuffered = true;

        // Scrolling animation timer
        scrollTimer = new Timer { Interval = 16 }; // ~60fps
        scrollTimer.Tick += ScrollTimer_Tick;
    }

    public new string Text
    {
        get => fullText;
        set
        {
            fullText = value;
            scrollPosition = 0;
            PrepareTextBitmap();
            scrollTimer.Start();
        }
    }

    private void PrepareTextBitmap()
    {
        // Clean up previous resources
        textBitmap?.Dispose();
        textGraphics?.Dispose();

        // Measure text width
        using (var g = this.CreateGraphics())
        {
            textWidth = (int)g.MeasureString(fullText, this.Font).Width;
        }

        // Create bitmap that's wider than needed for scrolling
        int bitmapWidth = textWidth + this.Width * 2;
        textBitmap = new Bitmap(bitmapWidth, this.Height);
        textGraphics = Graphics.FromImage(textBitmap);

        // Draw text on bitmap (right-aligned within the bitmap)
        textGraphics.Clear(this.BackColor);
        textGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        // Draw Urdu text right-aligned within the bitmap
        textGraphics.DrawString(fullText, this.Font, new SolidBrush(this.ForeColor),
                              new RectangleF(this.Width, 0, textWidth, this.Height),
                              new StringFormat(StringFormatFlags.DirectionRightToLeft));
    }

    private void ScrollTimer_Tick(object sender, EventArgs e)
    {
        scrollPosition -= 1f; // Adjust scrolling speed here

        // Reset position when text has fully scrolled
        if (scrollPosition < 0)
        {
            scrollPosition = textWidth + this.Width;
        }

        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (textBitmap != null)
        {
            // Draw the portion of text that should be visible
            e.Graphics.DrawImage(textBitmap,
                                new Rectangle(0, 0, this.Width, this.Height),
                                new Rectangle((int)scrollPosition, 0, this.Width, this.Height),
                                GraphicsUnit.Pixel);
        }
        else
        {
            base.OnPaint(e);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            scrollTimer?.Dispose();
            textBitmap?.Dispose();
            textGraphics?.Dispose();
        }
        base.Dispose(disposing);
    }
}