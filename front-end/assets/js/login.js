function logar() {

	let email = document.getElementById("email").value
	let senha = document.getElementById('senha').value
	
	fetch(`https://localhost:5001/api/usuarios/autentica/?email=${email}&senha=${senha}`)
	.then(response => {
		if (response.ok) {
			window.location.href="./index.html";
		}else{
			alert('Usuário ou senha incorreto!')
		}
	})
}


