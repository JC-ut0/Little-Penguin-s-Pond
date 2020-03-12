// 获取容器
var pics = document.getElementById("pics")
var n = 1;
//设置时钟
setInterval(function(){
	// alert(n);
	if (n>4) n=1;
	n++;
	pics.innerHTML = "<img src='img/" + n +".jfif' alt='first picture'>"
}, 2000)
