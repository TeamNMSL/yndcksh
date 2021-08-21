# yndcksh

## yong ni de ci ku shuo hua

### 用你的詞庫説話
我不知道你們能不能好好説話x

本項目遵守AGPL3協議(我不知道這是什麽)

## What's This

這事一個沒有任何用處的東西，用來將中國語的拼音首字母轉換爲中國語的單詞的一個沒有任何用處的類庫

其中用到的现代汉语常用词表.json來自倉庫[不能好好説話](https://github.com/RimoChan/bnhhsh)，本項目的~~創意~~也來自這個項目

## 使用方法

```
https://github.com/TeamNMSL/yndcksh.git
```

### 如何使用

在你自己的工程文件中添加項目引用

```
using TeamNMSL.yndcksh
```

創建一個CNPronunciationConverter的實例

使用裏面的GetTextFromAbbreviation方法獲取首字母轉的中國語文字

### 詞庫格式

詞庫使用JsonArray格式（大概

反正就是這個樣子的格式

```
["啊這","你這","他這","我這"]
```

## Demo

```c#
using System;
using TeamNMSL.yndcksh;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string CX = Console.ReadLine().Replace("\n", "").Replace("\r", "");
            Console.WriteLine(new CNPronunciationConverter("[\"我操\",\"呃呃\"]").GetTextFromAbbreviation(CX));
            Console.ReadKey();
        }
    }
}

```

