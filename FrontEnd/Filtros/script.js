let products = []; // Array global para armazenar os produtos

// Função para buscar os produtos da API
async function fetchProducts() {
  const apiUrl = "https://localhost:7248/Produto/visualizar-produto";
  
  try {
    const response = await fetch(apiUrl, {
      method: "GET",
      headers: {
        Accept: "application/json",
      },
    });
    
    // Verifica se a resposta foi bem-sucedida
    if (!response.ok) {
      throw new Error('Erro ao buscar produtos.');
    }

    // Espera a resposta ser convertida para JSON
    const data = await response.json();
    
    // Armazena os produtos no array global
    products = data;

    // Exibe os produtos após o carregamento
    displayProducts(products);

  } catch (error) {
    console.error('Erro ao carregar produtos:', error);
  }
}

// Função para exibir a lista de produtos
function displayProducts(filteredProducts) {
  const productList = document.getElementById("productList");
  productList.innerHTML = ""; // Limpa a lista atual

  // Exibe os produtos filtrados
  filteredProducts.forEach((product) => {
    const li = document.createElement("li");

    // Acessa os atributos do produto conforme o formato
    li.innerHTML = `
      <strong>${product.nome}</strong><br>
      Preço: R$ ${product.preco.toFixed(2)}<br>
      Descrição: ${product.descricao}<br>
      Quantidade em estoque: ${product.quantidadeEmEstoque} unidades<br>
      Fornecedor: ${product.fornecedorname.nome}<br>
      FornecedorId: ${product.fornecedorId}
    `;
    
    productList.appendChild(li);
  });
}

// Função para filtrar os produtos com base nos critérios de pesquisa e categoria
function filterProducts() {
  const searchQuery = document.getElementById("searchBar").value.toLowerCase(); // Obtém o termo de pesquisa
  const selectedCategory = document.getElementById("categoryFilter").value; // Obtém a categoria selecionada

  // Filtra os produtos com base nos critérios de pesquisa
  const filteredProducts = products.filter((product) => {
    const matchesCategory = selectedCategory
      ? product.nome.toLowerCase().includes(selectedCategory.toLowerCase()) // Alterado para "includes"
      : true;
    const matchesSearch = product.nome.toLowerCase().includes(searchQuery);

    return matchesCategory && matchesSearch;
  });

  // Exibe os produtos filtrados
  displayProducts(filteredProducts);
}

// Inicializa a busca de produtos ao carregar a página
fetchProducts();

// Adiciona eventos para a barra de pesquisa e o dropdown de categoria
document.getElementById("searchBar").addEventListener("input", filterProducts);
document.getElementById("categoryFilter").addEventListener("change", filterProducts);
