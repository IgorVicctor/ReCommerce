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

        body = {
            "nome": nome,
            "preco": preco,
            "marca": marca,
            "tempoDeUso": tempoDeUso,
            "qtdEstoque": qtdEstoque,
            "imagem": imagem
        }

        fazPost(url, body)

        alert('Produto cadastrado com sucesso!');
      
}  

