const carregarProdutos = async () => {
    const response = await fetch(`https://localhost:5001/api/produtos/`)
    const dados = await response.json()
    console.log(dados)
    

    dados.forEach(item => {
        const containerProdutoElement = document.getElementById('container-produtos')

        const template = document.getElementById("produto-template")

        const produtoElement = document.importNode(template.content, true)

        const itens_produto = produtoElement.querySelectorAll('span')

        itens_produto[0].innerText = item.nome
        
        containerProdutoElement.append(produtoElement)
    })
}

window.onload = () =>{
    carregarProdutos()

}

function logout(){
    var sair = confirm("Voce deseja sair?");
    if(sair == true){
        window.location.href="./login.html"
    }
    
}