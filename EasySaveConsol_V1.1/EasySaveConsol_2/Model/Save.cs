namespace EasySaveConsol_2
{
    class Save
    {
        //Creation of all the attributes and using of getter and setter
        //they are necessary for all the rest of the application we gonna use them for all part in relation with the save work
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilesSource { get; set; }
        public string FilesTarget { get; set; }
        public string Type { get; set; }
    }
}
