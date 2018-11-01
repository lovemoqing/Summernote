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

![blockchain](https://www.cnblogs.com/images/cnblogs_com/sunshine-wy/1332543/o_SummernoteExample.jpg)
