namespace SolarLunarName.Standard.RestServices.LocalJson{

    class Helpers {

        static internal void TestPath(string Path){
             if(!System.IO.Directory.Exists(Path)){
                 throw new System.ArgumentException("Base URl Does not resolve.");
             }
        }

    }
}
