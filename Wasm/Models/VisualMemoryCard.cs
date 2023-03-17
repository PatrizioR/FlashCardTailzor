namespace FlashCardTailzor.Wasm.Models
{
    public class VisualMemoryCard
    {
        public MemoryCard Card { get; set; } = null!;
        public bool IsFlipped { get; set; }
    }
}
