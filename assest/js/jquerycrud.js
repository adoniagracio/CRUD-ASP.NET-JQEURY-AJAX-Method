function readAll() {
	$.ajax({
		url: 'https://localhost:7072/api/GetCategory',
		method: 'GET',
		success: function(data) {
			let table = $('#tab');
			$.each(data.payload, function(index, category) {
				index += 1;
				const categoryID = category.categoryId;
				const UserId = category.user.userId;
				const userName = category.user.userName;
				console.log(UserId);
				$('#UserBtn').html(`${userName} <i class="fa fa-caret-down"></i>`);
				table.append('<tr><td>' + index + '</td><td>' + category.nameCategory +
					'</td><td><button class="edit"  onClick="editItem(' + categoryID + ')" >' + "Edit" +
					'</button>' + '<button class="delete" onClick="deleteItem(' + categoryID + ')">' + "DELETE" + '</button ></td></tr>');
			});
		},
		error: function() {
			console.error('Gagal Mengambil Data');
		}
	});
}
readAll();

   
$('#CreateForm').on('submit', function(e) {
	e.preventDefault();
	$(this).prop('disabled', true); 
    var newCategoryName = $('#namecategory').val();
	$.ajax({
		url: 'https://localhost:7072/api/Post',
		method: 'POST',
		contentType: 'application/json',
		data: JSON.stringify({NameCategory: newCategoryName , userId: 7}),
		success: function() {
			location.reload();
		},
		error: function(textStatus) {
			alert('Failed to send form data: ' + textStatus);
		}
	});
});


function editItem(id) {
	document.querySelector(".update_form").style.display = "block";
	const closeButton = document.querySelector('.update_close'),
	updatebutton = document.querySelector('.edit'),
	submitbtn = document.getElementById("Submitbtn");

	updatebutton.addEventListener('click', () => {
		home.classList.add("show");
	});

	closeButton.addEventListener('click', () => {
		document.querySelector(".update_form").style.display = "none";
		home.classList.remove("show")
	});

	submitbtn.addEventListener('click', () => {
		var updateCategoryName = $('#updatectgry').val();
		$.ajax({
			url: 'https://localhost:7072/api/Put/' + id,
			method: 'PUT',
			contentType: 'application/json',
			data:JSON.stringify({NameCategory: updateCategoryName}),
			success: function(data) {
				location.reload();
			},
			error: function(error) {
				console.error('Failed to update item with ID ' + id + ': ' + error);
			}
		});
		document.querySelector(".update_form").style.display = "none";
	});
}


function deleteItem(id) {
	document.querySelector(".modal").style.display = "block";
	const closeModalButton = document.getElementById("closeModal"),
		deletebtn = document.querySelector('.delete'),
		confirmBTN = document.getElementById("confimbtn");

	deletebtn.addEventListener('click', () => {
		home.classList.add("show");
	});
	closeModalButton.addEventListener("click", function() {
		document.querySelector(".modal").style.display = "none";
		home.classList.remove("show");
	});
	confirmBTN.addEventListener("click", function() {

		$.ajax({
            url: 'https://localhost:7072/api/Delete/' + id,
            method: 'DELETE',
            success: function (data) {
				location.reload();
            },
            error: function (error) {
                console.error('Failed to delete item with ID ' + id + ': ' + error);
            }
        });
    
	});

	$(document).ready(function() {
		$.ajax({
			url: 'https://localhost:7072/api/GetCategory', 
			method: 'GET',
			success: function(data) {
				var newText = data.userName; 
				$('#UserBtn').text(newText);
			},
			error: function(xhr, status, error) {
				console.error(error);
			}
		});
	});



}
