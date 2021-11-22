
	const getDados = () => {
		const url = 'https://localhost:5001/api/Usuarios/1'
	
		fetch(url)
			.then(response => response.json())
			.then(data =>{
				console.log(`${data.email}`)
				console.log(`${data.senha}`)
				var email = `${data.email}`
				var senha = `${data.senha}`
			})	
			
	}
	

	getDados()
	
function logar(){
	if(email == 'email'){
		alert('Ok')
	} else{
		alert('Errado')
	}
}

/*function logar(){
	var usuario = document.getElementById("usuario");
	var senha = document.getElementById("senha");

	console.log(usuario.value+senha.value);

	if(usuario.value == "admin" && senha.value == "admin"){
		localStorage.setItem("acesso",true);
		alert("Usuario autenticado!");
		windows.location.href = "index.html"
	}else{
		alert("Usuario ou senha invalidos!");
	}
}*/
