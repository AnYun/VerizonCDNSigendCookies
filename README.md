# 前言 #

雖然前後台分離會是較安全的作法，但是仍然會有些情境需要有多重登入的情形，如果只使用 
`Authorize` Filter 又加上沒做好權限控管，可能會導致前台登入之後也會有權限進入後台，造成安全上的漏洞，因此寫了這一個套件來處理這樣的情形，利用自定的 Forms Authentication Cookies Name 來達成多重登入的效果，並且也提供了幾個擴充方法可以用來驗證權限。


# 其它 #

開發環境：

Visual Studio 2019

.Net Core 3.1

# License #
[Mit License](http://opensource.org/licenses/mit-license.php)

**by AnYun - [https://dotblogs.com.tw/anyun/](https://dotblogs.com.tw/anyun/)**