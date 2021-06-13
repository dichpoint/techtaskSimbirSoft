namespace techtaskSimbirSoft
{
    class UniqueWord // class-model
    {
        public int id { get; set; }
        private string word;
        private int count;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public UniqueWord() { }

        public UniqueWord(string word, int count)
        {
            this.word = word;
            this.count = count;
        }
    }
}