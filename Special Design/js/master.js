//class selector
var landingPage=document.getElementById("imgg");

var img=["1.0.png","1.1.png"];


setInterval(()=>{
//RandomNumber for picture
var RandumNum=Math.floor(Math.random()*img.length)  
landingPage.setAttribute("src",'/imgs/'+img[RandumNum]+'')
},5000)


document.getElementById("stb").onclick=function(){
        this.classList.toggle("open")

    };

function dark() {
document.getElementById("L1").classList.toggle("backGround-color");
document.getElementById("L2").classList.toggle("backGround-color");

document.getElementById("L3").classList.toggle("backGround-color");
document.getElementById("L4").classList.toggle("backGround-color");

const liElements = document.getElementsByClassName('list-a');

    // Loop through each li element and change its color to white
    for (let i = 0; i < liElements.length; i++) {
    liElements[i].classList.toggle("w-color")
    }



    const hpElements = document.getElementsByClassName('drk');

    // Loop through each li element and change its color to white
    for (let i = 0; i < hpElements.length; i++) {
        hpElements[i].classList.toggle("w-color")
    }
}

 // Get all the li elements inside the ul
 const slider = document.querySelector('.slider');
 const prevBtn = document.querySelector('.prev');
 const nextBtn = document.querySelector('.next');
 
 let slideWidth = slider.clientWidth / 3;
 let slideCount = slider.children.length;
 let currentIndex = 0;
 
 slider.style.transform = `translateX(${-slideWidth * currentIndex}px)`;
 
 prevBtn.addEventListener('click', () => {
   if (currentIndex > 0) {
     currentIndex--;
     slider.style.transform = `translateX(${-slideWidth * currentIndex}px)`;
   }
 });
 
 nextBtn.addEventListener('click', () => {
   if (currentIndex < slideCount - 3) {
     currentIndex++;
     slider.style.transform = `translateX(${-slideWidth * currentIndex}px)`;
   }
 });
 
