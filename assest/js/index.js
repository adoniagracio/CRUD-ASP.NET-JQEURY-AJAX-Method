const formOpenBtn = document.querySelector("#form-open"),
	home = document.querySelector(".home"),
	formContainer = document.querySelector(".form_container"),
	formCloseBtn = document.querySelector(".form_close"),
	signupBtn = document.querySelector("#signup"),
	loginBtn = document.querySelector("#login"),
	pwShowHide = document.querySelectorAll(".pw_hide"),
	registerbtn = document.querySelector('#register')

formOpenBtn.addEventListener("click", () => home.classList.add("show"));
formCloseBtn.addEventListener("click", () => home.classList.remove("show"));

pwShowHide.forEach((icon) => {
	icon.addEventListener("click", () => {
		let getPwInput = icon.parentElement.querySelector("input");
		if (getPwInput.type === "password") {
			getPwInput.type = "text";
			icon.classList.replace("uil-eye-slash", "uil-eye");
		} else {
			getPwInput.type = "password";
			icon.classList.replace("uil-eye", "uil-eye-slash");
		}
	});
});

signupBtn.addEventListener("click", (e) => {
	e.preventDefault();
	formContainer.classList.add("active");
});
loginBtn.addEventListener("click", (e) => {
	e.preventDefault();
	formContainer.classList.remove("active");
});

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

const aboutUsButton = document.querySelector("#about-us-button");
const aboutUsPage = document.querySelector("#about-us");

aboutUsButton.addEventListener("click", () => {
	aboutUsPage.classList.toggle("active");
	aboutUsPage.style.display = "block";
});


function isValidEmail(email) {
	const emailRegex = /\S+@\S+\.\S+/;
	return emailRegex.test(email);
	}
	
function isValidPassword(password) {
return password.trim() !== ''; 
}

const errorPopup = document.getElementById('error-popup');

function ErrorPopup() {
    errorPopup.style.display = 'block';
}

function closeerrorPopup() {
    errorPopup.style.display = 'none';
}

function closeconfirm() {
    errorPopup.style.display = 'none';
}


 function login() {
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    if (!isValidEmail(email)) {
        console.log('Email is not valid, use this format "example@example.com"');
		ErrorPopup();
        return;
    }

    if (!isValidPassword(password)) {
        console.log('Password is required');
		ErrorPopup();
        return;
    }

	
	fetch('https://localhost:7072/User/login', {
		method: 'POST',
		headers: {
		   'Content-Type': 'application/json'
		},
		body: JSON.stringify({
		   useremail: email,
		   userpassword: password
		})
	   })
	   .then(response => {
		if (!response.ok) {
		   throw new Error('Login failed.');
		}
		return response.json();
	   })
	   .then(data => {
		console.log('Login success:', data);
		window.location.href = 'Main.html';
	   })
	   .catch(error => {
		ErrorPopup();
		console.error('Login error:', error);
	   });
	   
 }

 
 function reg() {
	const name = document.getElementById('registername').value,
	 email = document.getElementById('registeremail').value,
     password = document.getElementById('registerpassword').value,
	 confimpassword = document.getElementById('registerconfirmpassword').value,
	 agreeCheckbox = document.getElementById('agree');
	

    if (!isValidEmail(email)) {
        alert('Email is not valid, use this format "example@example.com"');
        return;
    }

    if (!isValidPassword(password)) {
        alert('Password is required');
        return;
    }

	if (!agreeCheckbox.checked) {
		alert('You must agree to the terms and conditions.');
		return;
	}

	if (password !== confimpassword) {
		alert('confirm password not same');
		console.log(name,email,password,confimpassword);
		return;
	}


	fetch('https://localhost:7072/User/register',{
		method: 'POST',
		headers: {
		   'Content-Type': 'application/json'
		},
		body: JSON.stringify({
		   userName: name,
		   useremail: email,
		   userpassword: password
		})
	   })
	   .then(response => {
		if (!response.ok) {
		   throw new Error('Registration failed.');
		}
		return response.json();
	   })
	   .then(data => {
		console.log('Registration success:', data);
	   })
	   .catch(error => {
		console.error('Login error:', error);
	   });

 }

