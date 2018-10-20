using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 全局数据管理类
public class GlobalDataManager : Singleton<GlobalDataManager> {
    // 打开过的目录
    public string openedFileDir { get; set; }
    // 播放间隔
    public int playInterval { get; set; }

    public List<Sprite> spriteList { get; set; }

    // 初始化
    public override void Init() {
        spriteList = new List<Sprite>();
    }

    // 加载文件路径
    public bool ReloadSpriteList(string dir = null) {
        // 处理目录为空逻辑
        if (dir == null) {
            if (openedFileDir != null) {
                dir = openedFileDir;
            } else {
                return false;
            }
        }

        // 判断目录是否有效
        if (Directory.Exists(dir) == false) {
            return false;
        }

        openedFileDir = dir;
        spriteList.Clear();

        string[] files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
        foreach (string file in files) {
            if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg")) {
                //创建文件读取流
                FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                fileStream.Seek(0, SeekOrigin.Begin);
                //创建文件长度缓冲区
                byte[] bytes = new byte[fileStream.Length];
                //读取文件
                fileStream.Read(bytes, 0, (int) fileStream.Length);
                //释放文件读取流
                fileStream.Close();
                fileStream.Dispose();
                fileStream = null;

                //创建Texture
                int width = Screen.width;
                int height = Screen.height;
                Texture2D texture = new Texture2D(width, height);
                texture.LoadImage(bytes);

                //创建Sprite
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                spriteList.Add(sprite);
            }
        }

        return true;
    }
}