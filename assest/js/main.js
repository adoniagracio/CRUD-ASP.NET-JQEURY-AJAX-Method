const mainMenu = document.querySelector('.mainMenu');
const closeMenu = document.querySelector('.closeMenu');
const openMenu = document.querySelector('.openMenu');
const menu_items = document.querySelectorAll('nav .mainMenu li a');

openMenu.addEventListener('click', show);
closeMenu.addEventListener('click', close);

menu_items.forEach(item => {
	item.addEventListener('click', function() {
		close();
	})
})

function show() {
	mainMenu.style.display = 'flex';
	mainMenu.style.top = '0';
}

function close() {
	mainMenu.style.top = '-100%';
}

const aboutUsButton = document.querySelector("#about-us-button"),
	aboutUsPage = document.querySelector("#about-us"),
	CategoryButton = document.querySelector("#category-button"),
	CategoryPage = document.querySelector("#category"),
	massage = document.querySelector("#massage-log");

aboutUsButton.addEventListener("click", () => {
	aboutUsPage.classList.toggle("active");
	aboutUsPage.style.display = "block";
	CategoryPage.style.display = "none";
});


CategoryPage.style.display = "block";
CategoryButton.addEventListener("click", () => {
	CategoryPage.classList.toggle("active");
	CategoryPage.style.display = "block";
	aboutUsPage.style.display = "none";
});


const closeButton = document.querySelector('.form_close'),
	createForm = document.getElementById('CreateForm'),
	updateForm = document.getElementById('updateForm'),
	addcategorybtn = document.getElementById('addcategory'),
	homepage = document.getElementById("home")


addcategorybtn.addEventListener("click", function() {
	// homepage.style.filter = "blur(8px)";
	createForm.style.display = "block";
	homepage.classList.add("show");
});

closeButton.addEventListener("click", function() {
	// homepage.style.filter = "none";
	createForm.style.display = "none";
	homepage.classList.remove("show");
});
closeButton.addEventListener('click', () => {
	createForm.style.display = 'none';
	document.querySelector(".add_div").style.display = "block";
	homepage.classList.remove("show");
});



