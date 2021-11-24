fetch(`https://localhost:5001/api/usuarioprodutos/1`)
        .then(response => {
            if (response.ok) {
                console.log('entrou')
            }else{
                alert('nao entrou')
            }
        })

/*fetch('https://localhost:5001/api/usuarioprodutos/1')
    .then((response) => response.json())
    .then(function (data) {
        let produtos = produtos.results;
        console.log(produtos);
        return produtos.map(function (produto) {

            let nome = document.createElement('h2');
            let marca = document.createElement('p');
            let imagem = document.createElement('img');
            imagem.src = produto.picture.medium;
            nome.innerHTML = produto.nome;
            marca.innerHTML = produto.marca;

            var ul = document.getElementById('title');
            let li = document.createElement('pi');
            li.appendChild(nome);
            li.appendChild(imagem);
            li.appendChild(marca);
            ul.appendChild(li);
        })
    })
    .catch(function (error) {
        console.log(error);
    });*/

        
        

    
    