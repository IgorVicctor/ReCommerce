function fazPost(url, body) {
    console.log("Body=", body)
    let request = new XMLHttpRequest()
    request.open("POST", url, true)
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8")
    request.send(JSON.stringify(body))

    request.onload = function() {
        console.log(this.responseText)
    }

    return request.responseText
}

function cadastraProduto() {
    event.preventDefault()
    let url = "https://localhost:5001/api/produtos"
    let nome = document.getElementById("nome").value
    let preco = document.getElementById("preco").value
    let marca = document.getElementById("marca").value
    let tempoDeUso = document.getElementById("tempoDeUso").value
    let qtdEstoque = document.getElementById("qtdEstoque").value
    let imagem = document.getElementById("imagem").value

    let id = Math.floor(Math.random() * 100);

        body = {
            "id": id,
            "nome": nome,
            "preco": preco,
            "marca": marca,
            "tempoDeUso": tempoDeUso,
            "qtdEstoque": qtdEstoque,
            "imagem": imagem,
        }

        fazPost(url, body)

        {
            let url = "https://localhost:5001/api/usuarioprodutos"


            body = {
                UsuarioId: localStorage.id,
                ProdutoId: id
            }

                fazPost(url, body)
      
        }   

        /*fetch('https://localhost:5001/api/usuarioprodutos',{
            method:"POST",
            headers:{
                "Content-Type": 'application/json'
            },
            body: JSON.stringify(data)
        });
            console.log(data)
            })
        }*/

        alert('Produto cadastrado com sucesso')
        document.location.reload(true);

}


	/*let email = document.getElementById("email").value
	let senha = document.getElementById('senha').value

    let url = `https://localhost:5001/api/usuarioprodutos/${}`
	
	fetch(`https://localhost:5001/api/usuarioprodutos`)
	.then(response => {
		if (response.ok) {
			window.location.href="./index.html";
		}else{
			alert('Usuário ou senha incorreto!')
		}
	})*/


