namespace YumBlazor.Services
{
    public class SharedStateService
    {
        public event Action OnChange;
        public int _totalCartCount;

        public int TotalCartCount 
        { 
            get => _totalCartCount; 
            set 
            { 
                _totalCartCount = value; 
                NotifyStateChanged(); 
            } 
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
