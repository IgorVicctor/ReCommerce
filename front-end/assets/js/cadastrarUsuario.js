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

function cadastraUsuario() {
    event.preventDefault()
    let url = "https://localhost:5001/api/usuarios"
    let nome = document.getElementById("nome").value
    let email = document.getElementById("email").value
    let usuario = document.getElementById("usuario").value
    let telefone = document.getElementById("telefone").value
    let senha = document.getElementById("senha").value

    body = {
        "nome": nome,
        "email": email,
        "usuario": usuario,
        "telefone": telefone,
        "senha": senha
    }

    fazPost(url, body)

    {
        event.preventDefault()
        let url = "https://localhost:5001/api/Enderecos"
        let cep = document.getElementById("cep").value
        let bairro = document.getElementById("bairro").value
        let rua = document.getElementById("rua").value
        let estado = document.getElementById("estado").value
        let cidade = document.getElementById("cidade").value
        let residencia = document.getElementById("residencia").value
    
        body = {
            "residencia": residencia,
            "cep": cep,
            "bairro": bairro,
            "estado": estado,
            "rua": rua,
            "cidade": cidade,
        }
          
        fazPost(url, body)
    }

    alert('Usuário cadastrado com sucesso!');

    //window.location.href="login.html";       
}
