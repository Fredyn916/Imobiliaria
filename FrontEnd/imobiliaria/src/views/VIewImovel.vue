<template>
    <div class="container">
      <h1>Filtros de imóveis</h1>
      <div class="filter-container">
        <label for="categoryFilter">Categoria:</label>
        <select id="categoryFilter" v-model="selectedCategory" class="filter-select">
          <option value="">Todas</option>
          <option value="Estiloso">Estiloso</option>
          <option value="Samsung">Samsung</option>
        </select>
      </div>
  
      <div class="filter-container">
        <label for="searchBar">Pesquisar Imóvel:</label>
        <input type="text" id="searchBar" v-model="searchQuery" @input="filterImoveis"
          placeholder="Digite o nome do imóvel..." class="filter-input" />
      </div>
  
      <ul class="product-list">
        <li v-for="Imovel in filteredImoveis" :key="Imovel.id" class="product-item">
          <strong>{{ Imovel.tipo }}</strong><br>
          Preço: R$ {{ Imovel.preco }}<br>
          Área: {{ Imovel.area }} m²<br>
          CEP: {{ Imovel.cep }}<br>
          Rua: {{ Imovel.rua }}<br>
          Número: {{ Imovel.numero }}<br>
          Bairro: {{ Imovel.bairro }}<br>
          Cidade: {{ Imovel.cidade }}<br>
          Unidade Federativa: {{ Imovel.unidadeFederativa }}<br>
          Endereço: {{ Imovel.endereco }}<br>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    name: 'ViewImovel',
    data() {
      return {
        imoveis: [],
        searchQuery: "",
        selectedCategory: "",
        filteredImoveis: []
      };
    },
    methods: {
      async fetchImoveis() {
        const apiUrl = "https://localhost:7082/Imovel/ListarImoveis";
  
        try {
          const response = await fetch(apiUrl, {
            method: "GET",
            headers: {
              Accept: "application/json",
            },
          });
  
          if (!response.ok) {
            throw new Error('Erro ao buscar imóveis.');
          }
  
          const data = await response.json();
          this.imoveis = data;
          this.filteredImoveis = data;
        } catch (error) {
          console.error('Erro ao carregar imóveis:', error);
        }
      },
  
      filterImoveis() {
        this.filteredImoveis = this.imoveis.filter((imovel) => {
          const matchesCategory = this.selectedCategory
            ? imovel.tipo.toLowerCase().includes(this.selectedCategory.toLowerCase())
            : true;
          const matchesSearch = imovel.tipo.toLowerCase().includes(this.searchQuery.toLowerCase());
  
          return matchesCategory && matchesSearch;
        });
      }
    },
    watch: {
      selectedCategory() {
        this.filterImoveis();
      },
      searchQuery() {
        this.filterImoveis();
      }
    },
    mounted() {
      this.fetchImoveis();
    }
  };
  </script>
  
  <style scoped>
  .container {
    font-family: 'Arial', sans-serif;
    padding: 20px;
    background-color: #f9f9f9;
    max-width: 800px;
    margin: 0 auto;
  }
  
  h1 {
    text-align: center;
    color: #333;
    margin-bottom: 20px;
  }
  
  .filter-container {
    margin-bottom: 20px;
    display: flex;
    flex-direction: column;
  }
  
  label {
    font-weight: bold;
    color: #333;
    margin-bottom: 5px;
  }
  
  .filter-select,
  .filter-input {
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
  }
  
  .filter-select {
    cursor: pointer;
  }
  
  .product-list {
    list-style-type: none;
    padding: 0;
  }
  
  .product-item {
    background-color: #fff;
    padding: 15px;
    margin-bottom: 10px;
    border-radius: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
  
  .product-item:hover {
    cursor: pointer;
  }
  
  .product-item strong {
    color: #333;
  }
  
  @media (max-width: 600px) {
    .container {
      padding: 10px;
    }
  
    .filter-select,
    .filter-input {
      width: 100%;
      box-sizing: border-box;
    }
  }
  </style>
  