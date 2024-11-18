<template>
  <div class="container">
    <div class="filter-container">
      <!-- Barra de pesquisa -->
      <input type="text" id="searchBar" v-model="searchQuery" @input="filterImoveis"
        placeholder="Digite a cidade, bairro ou UF..." class="filter-input" />
    </div>

    <div class="filter-container">
      <!-- Filtro de categoria (opcional) -->
      <select id="categoryFilter" v-model="selectedCategory" class="filter-select">
        <option value="">Todas</option>
        <option value="Apartamento">Apartamento</option>
        <option value="Casa">Casa</option>
      </select>
    </div>
  </div>

  <div class="Imovel__container">
    <ul class="imovel__container__list">
      <li v-for="Imovel in filteredImoveis" :key="Imovel.id" class="imovel__container__item">
        <div class="Imovel__Container__internal__container">
          <div class="Imovel__Container__box__Left">
            <div class="Imovel__Container__box__images">
              <img v-if="Imovel.urLsImagens && Imovel.urLsImagens.length > 0" :src="Imovel.urLsImagens[0]"
                alt="Imagem do imóvel" class="imovel-image" />
            </div>
          </div>
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

        // Filtragem baseado na pesquisa
        const matchesSearch = this.searchQuery
          ? (imovel.cidade.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
            imovel.bairro.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
            imovel.unidadeFederativa.toLowerCase().includes(this.searchQuery.toLowerCase()))
          : true;

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
  flex-wrap: wrap;
  align-items: center;
  justify-content: flex-start;
  padding-inline: 3rem;
  margin: 20px;
  gap: 15px;
}

.filter-container {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.filter-input,
.filter-select {
  width: 100%;
  padding: 12px;
  border-radius: 8px;
  border: 1px solid #7c98a7;
  font-size: 1rem;
}

.filter-select {
  background: #fff;
  font-family: Hind, sans-serif;
  font-weight: 600;
  color: #333;
}

.Imovel__container {
  width: 100%;
}

.Imovel__Container__internal__container {
  display: flex;
  flex-wrap: wrap;
  gap: 15px;
}

.Imovel__Container__box__Left {
  flex: 1;
  max-width: 30%;
  max-height: 100%;
  display: flex;
}

.Imovel__Container__box__images img{
  width: 100%;
  height: 100%;
}

.Imovel__Container__box__Right {
  flex: 2;
  max-width: 70%;
  padding: 2rem;
  background: #fff;
}

.imovel__container__list {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 20px;
  padding: 0;
}

.imovel__container__item {
  width: 90%;
  max-width: 100%;
  max-height: 400px;
  height: auto;
  border: 5px solid #ededed;
  color: #000;
  border-radius: 10px;
  padding: 20px;
  list-style: none;
}

@media(max-width: 768px) {
  .container {
    padding: 10px;
    justify-content: center;
  }

  .filter-container {
    width: 100%;
    display: flex;
    flex-direction: column;
    gap: 10px;
  }

  .filter-input,
  .filter-select {
    width: 100%;
    padding: 10px;
  }

  .Imovel__Container__internal__container {
    flex-direction: column;
    align-items: center;
  }

  .Imovel__Container__box__Left,
  .Imovel__Container__box__Right {
    max-width: 100%;
    flex: none;
  }

  .imovel__container__item {
    width: 100%;
    padding: 15px;
  }
}

@media(max-width: 480px) {
  .container {
    flex-direction: column;
    padding: 10px;
  }

  .filter-input,
  .filter-select {
    padding: 8px;
    font-size: 14px;
  }

  .Imovel__Container__internal__container {
    flex-direction: column;
  }

  .Imovel__Container__box__Left,
  .Imovel__Container__box__Right {
    max-width: 100%;
    padding: 10px;
  }

  .imovel__container__item {
    width: 100%;
    padding: 10px;
  }
}
</style>
