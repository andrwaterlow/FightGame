namespace Assets.Scripts
{
    public interface IMovement
    {
        public void Move();
        public void LookAround();
        public void Jump();
        public bool Act();
    }
}