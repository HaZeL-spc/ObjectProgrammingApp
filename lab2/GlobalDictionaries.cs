using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie
{
    public static class GlobalDictionaries
    {
        public static Dictionary<int, IGame> games = new Dictionary<int, IGame>();
        public static Dictionary<int, IMod> mods = new Dictionary<int, IMod>();
        public static Dictionary<int, IReview> reviews = new Dictionary<int, IReview>();
        public static Dictionary<int, IUser> users = new Dictionary<int, IUser>();
        public static Dictionary<string, BinaryTree<object>> treeDict = new Dictionary<string, BinaryTree<object>>();
        public static Dictionary<string, BinaryTree<object>> treeDictTuple = new Dictionary<string, BinaryTree<object>>();
        public static Dictionary<string, Dictionary<string, BinaryTree<object>>> TypesBinaryTree = new Dictionary<string, Dictionary<string, BinaryTree<object>>>();
        public static Dictionary<string, string> communications = new Dictionary<string, string>();
        public static Dictionary<string, object> defaultGame = new Dictionary<string, object>();
        public static Dictionary<string, object> defaultReview = new Dictionary<string, object>();
        public static Dictionary<string, object> defaultMod = new Dictionary<string, object>();
        public static Dictionary<string, object> defaultUser = new Dictionary<string, object>();
        public static Dictionary<string, Dictionary<string, object>> defaultValues = new Dictionary<string, Dictionary<string, object>>();

        public static Dictionary<string, Func<Game, object>> fieldMappingsGame = new Dictionary<string, Func<Game, object>>();

    }
}
