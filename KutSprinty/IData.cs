﻿namespace KutSprinty
{
    public interface IData
    {
        public string PromptZadaniVstupu { get; }
        public string TypDat { get; }
        public bool ZkusZpracovatVstup(string hodnotaStr, out string hlaska);
        public bool ZkusKontrolu();
    }

}
