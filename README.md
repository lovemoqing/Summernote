# SummernoteExample
Summernote is a Super Simple WYSIWYG Editor on Bootstrap.
Link: http://summernote.org/

Download full source code: http://www.mediafire.com/download/q8pnc2bi9v6mp8n/SummernoteExample.rar



# 2018年11月1日15:51:36 更新说明

分割线上面是源码地址，本demo是基于SummernoteExample的源码修改的，结合了阿里云OSS的使用，目前只有上传图片到阿里云上。

原理如下：
    编辑器上传图片=>保存到本地磁盘（路径位于当前项目的文件夹下）=> 获取项目中图片文件夹位置，调用OSS接口进行上传=>返回OSS里的路径=>上传完毕以后删除项目文件夹里的图片。

后面返回OSS和删除本地文件夹里的图片没有做，后续或许会继续完善这个demo，目前只完成了上传过程的演示，具体的操作流程还需结合项目去使用。

PS：项目里OSS的配置需要改成自己的，如果没有的话要去OSS上购买相关服，由于这个是收费的所以代码里我替换成文案了，所以直接运行项目是上传不到OSS的。但是上传的效果是有的，图片也会在项目里生成。

![blockchain](https://images.cnblogs.com/cnblogs_com/sunshine-wy/1332543/o_SummernoteExample.jpg)


# 2018年11月14日19:05:29 更新说明

远程服务器部署了图片上传接口，现在支持图片上传到远程服务器了，并且会返回图片的远程路径。

如需使用，需要将index页面的ajax请求的url地址修改为新写的方法名。

另，不推荐使用案例中的接口，这个是我自己测试用的，最好可以自己搭建一个远程服务。

搭建图片服务器的教程：
[使用.net core搭建文件服务器](https://www.cnblogs.com/sunshine-wy/p/9959646.html)
