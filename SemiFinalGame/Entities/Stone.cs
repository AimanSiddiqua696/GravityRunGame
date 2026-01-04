using SemiFinalGame.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace SemiFinalGame.Entities
{
    public class Stone
    {
        public GameObject Body { get; set; }
        public PictureBox Sprite { get; set; }
        public IMovement Movement { get; set; }

        public Stone(PictureBox pictureBox, IMovement movement)
        {
            Sprite = pictureBox;
            Movement = movement;

            Body = new GameObject();
            Body.Position = new PointF(pictureBox.Left, pictureBox.Top);
            
            // Default size for stones, though sprite size is usually set before passing in
            Body.Size = new SizeF(pictureBox.Width, pictureBox.Height);
        }

        public void Update()
        {
            Movement?.Move(Body, null);

            Sprite.Left = (int)Body.Position.X;
            Sprite.Top = (int)Body.Position.Y;
        }
    }
}
