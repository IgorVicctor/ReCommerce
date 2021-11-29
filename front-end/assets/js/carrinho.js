const carregarProdutos = async () => {
    const response = await fetch(`https://localhost:5001/api/usuarioprodutos/produtos/?idUser=${localStorage.id}`)
    const dados = await response.json()
    console.log(dados)

    dados.forEach(item => {
        const containerProdutoElement = document.getElementById('container-produtos')

        const template = document.getElementById("produto-template")

        const produtoElement = document.importNode(template.content, true)

        const itens_produto = produtoElement.querySelectorAll('span')

        itens_produto[0].innerText = item.nome
        itens_produto[1].innerText = item.preco
        itens_produto[2].innerText = item.marca
        itens_produto[3].innerText = item.tempoDeUso
        itens_produto[4].innerText = item.qtdEstoque

        containerProdutoElement.append(produtoElement)
    })
}

window.onload = () =>{
    carregarProdutos()

}


        
        

    
    