//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Library.Helpers
//{
//    public class Cache
//    {

//        ObjectCache cache = MemoryCache.Default;
//        string fileContents = cache["filecontents"] as string;  

//    if (fileContents == null)  
//    {  
//        CacheItemPolicy policy = new CacheItemPolicy();

//        List<string> filePaths = new List<string>();
//        filePaths.Add("c:\\cache\\example.txt");  

//        policy.ChangeMonitors.Add(new
//        HostFileChangeMonitor(filePaths));  

//        // Fetch the file contents.  
//        fileContents =   
//            File.ReadAllText("c:\\cache\\example.txt");  

//        cache.Set("filecontents", fileContents, policy);  
//    }

//}
//}