<template>
  <div class="container">
    <div class="filter-container">
      <input type="text" id="searchBar" v-model="searchQuery" @input="filterImoveis"
        placeholder="Digite o nome do imóvel..." class="filter-input" />
    </div>

    <div class="filter-container">
      <select id="categoryFilter" v-model="selectedCategory" class="filter-select">
        <option value="">Todas</option>
        <option value="Estiloso">Estiloso</option>
        <option value="Fred">Fred</option>
      </select>
    </div>

  </div>
  <div class="Imovel__container">

    <ul class="imovel__container__list">
      <li v-for="Imovel in filteredImoveis" :key="Imovel.id" class="imovel__container__item">
        <div class="Imovel__Container__internal__container">
          <div class="Imovel__Container__box__Left"></div>
          <div class="Imovel__Container__box__Right">
            <strong> R$ {{ Imovel.preco }}</strong><br>
            Rua: {{ Imovel.rua }}<br>
            Endereço: {{ Imovel.endereco }}<br>
            Número: {{ Imovel.numero }}<br>
            Área: {{ Imovel.area }} m²<br>
            CEP: {{ Imovel.cep }}<br>
            Bairro: {{ Imovel.bairro }}<br>
            Cidade: {{ Imovel.cidade }}<br>
            Unidade Federativa: {{ Imovel.unidadeFederativa }}<br>
          </div>
        </div>
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
  display: flex;
  align-items: center;
  justify-content: flex-start;
  padding-left: 5rem;
  height: 100px;
  gap: 10px;
}

.filter-input {
  padding: 1rem 2rem;
  border-radius: 8px;
}

.filter-select {
  padding: 15px 34px 14px 14px;
  border: 1px solid #7c98a7;
  border-radius: 8px;
  background: #fff;
  font-family: Hind, sans-serif;
  font-weight: 600;
  font-size: 16px;
  line-height: 17px;
  color: #000;
  user-select: none;
  cursor: pointer;
  white-space: nowrap;
  text-overflow: ellipsis;
  overflow: hidden;
}

.Imovel__container {
  height: auto;
  width: 100%;
}

.Imovel__Container__internal__container {
  display: flex;
}

.Imovel__Container__box__Left {
  flex: 1;
  border: 1px solid black;
  max-width: 30%;
  max-height: 100%;
}

.Imovel__Container__box__Right {
  flex: 1;
  border: 1px solid black;
  max-width: 70%;
  padding: 2rem;
}

.imovel__container__list {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 20px;
}

.imovel__container__item {
  width: 90%;
  max-height: 400px;
  height: auto;
  border: 5px solid #ededed;
  color: #000;
  border-radius: 10px;
}
</style>
