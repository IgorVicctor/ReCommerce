function logar() {

	let email = document.getElementById("email").value
	let senha = document.getElementById('senha').value
	
	fetch(`https://localhost:5001/api/usuarios/autentica/?email=${email}&senha=${senha}`)
	.then(response => {
		if (response.ok) {

			for (var i = 0; i < 10; i++) {
				fetch(`https://localhost:5001/api/usuarios/${i}`)
				.then((response) => response.json())
				.then(function (data) {
					let authors = data;
					if(email == authors.email){
						localStorage.setItem("id", authors.id);
						window.location.href="./index.html";
						return authors.id;		
					}
					
				})
			  }
			
		}else{
			alert('Usuário ou senha incorreto!')
		}
	})

	

}


