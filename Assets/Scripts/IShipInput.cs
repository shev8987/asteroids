public interface IShipInput
{
    float Rotation { get; }
    
    float Thrust { get; }
    void ReadInput();
}
