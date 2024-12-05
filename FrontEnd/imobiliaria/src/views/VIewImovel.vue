<template>
  <div ref="targetSection">
    <div class="container">
      <!-- Filtro de busca -->
      <div class="filter-container">
        <input
          type="text"
          id="searchBar"
          v-model="searchQuery"
          @input="filterImoveis"
          placeholder="Digite a cidade, bairro ou Rua..."
          class="filter-input"
        />
      </div>

      <!-- Filtro por tipo de imóvel -->
      <div class="filter-container">
        <select
          id="categoryFilter"
          v-model="selectedCategory"
          @change="filterImoveis"
          class="filter-select"
        >
          <option value="">Todos os tipos</option>
          <option value="Apartamento">Apartamento</option>
          <option value="Casa">Casa</option>
          <option value="Lote">Lote</option>
          <option value="Comercial">Comercial</option>
          <option value="Rural">Rural</option>
          <option value="Terreno">Terreno</option>
        </select>
      </div>

      <!-- Filtro por tipo de serviço (compra, alugar, etc.) -->
      <div class="filter-container">
        <select
          id="serviceTypeFilter"
          v-model="selectedServiceType"
          @change="filterImoveis"
          class="filter-select"
        >
          <option value="">Todos os serviços</option>
          <option value="Compra">Compra</option>
          <option value="Aluguel">Aluguel</option>
        </select>
      </div>

      <!-- Filtro por faixa de preço -->
      <div class="filter-container">
        <label for="priceFilter">Faixa de preço:</label>
        <input
          type="number"
          id="minPrice"
          v-model.number="minPrice"
          placeholder="Preço mínimo"
          class="filter-input"
          @input="filterImoveis"
        />
        <input
          type="number"
          id="maxPrice"
          v-model.number="maxPrice"
          placeholder="Preço máximo"
          class="filter-input"
          @input="filterImoveis"
        />
      </div>
    </div>

    <!-- Lista de imóveis -->
    <div class="Imovel__container">
      <ul class="imovel__container__list">
        <li
          v-for="Imovel in filteredImoveis"
          :key="Imovel.id"
          class="imovel__container__item"
          @click="selecionarImovel(Imovel)"
        >
          <div class="Imovel__Container__internal__container">
            <div class="Imovel__Container__box__Left">
              <div class="Imovel__Container__box__images">
                <img
                  v-if="Imovel.urLsImagens && Imovel.urLsImagens.length > 0"
                  :src="Imovel.urLsImagens[0]"
                  alt="Imagem do imóvel"
                  class="imovel-image"
                />
              </div>
            </div>
            <div class="Imovel__Container__box__Right">
              <div class="Imovel__item__container">
                <div class="Imove__item__container__item">
                  <div class="Imovel__preco">
                    <h2><strong>R$ {{ formatPrice(Imovel.preco) }}</strong></h2>
                  </div>
                </div>
                <div class="Imove__item__container__item">
                  <div class="Imovel__rua">
                    <p>{{ Imovel.rua }}</p>
                  </div>
                  <div class="Imovel__endereco">
                    <p>{{ Imovel.bairro }}, {{ Imovel.cidade }}</p>
                  </div>
                </div>
                <div class="Imovel__areasComuns">
                  <div class="Imovel__area">
                    <p>{{ Imovel.area }} m²</p>
                  </div>
                  <ul class="Ul__AreasComuns">
                    <li v-for="area in Imovel.areasComuns" :key="area">
                      {{ area }}
                    </li>
                  </ul>
                </div>
                <div class="Imovel__descricao">{{ Imovel.descricao }}</div>
              </div>
            </div>
          </div>
        </li>
      </ul>
    </div>

    <!-- Botão fixo de rolagem -->
    <button @click="smoothScrollToSection" class="buttontosection">↓</button>
  </div>
</template>

<script>
export default {
  name: "ViewImovel",
  data() {
    return {
      imoveis: [],
      searchQuery: "",
      selectedCategory: "",
      selectedServiceType: "", // Novo campo para o tipo de serviço
      minPrice: null,
      maxPrice: null,
      filteredImoveis: [],
      selectedImovelId: null,
    };
  },

  mounted() {
    this.fetchImoveis();
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
          throw new Error("Erro ao buscar imóveis.");
        }

        const data = await response.json();
        this.imoveis = data;
        this.filteredImoveis = data;
      } catch (error) {
        console.error("Erro ao carregar imóveis:", error);
      }
    },

    filterImoveis() {
      this.filteredImoveis = this.imoveis.filter((imovel) => {
        const matchesCategory = this.selectedCategory
          ? imovel.tipo.toLowerCase().includes(this.selectedCategory.toLowerCase())
          : true;

        const matchesSearch = this.searchQuery
          ? imovel.cidade.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
            imovel.bairro.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
            imovel.rua.toLowerCase().includes(this.searchQuery.toLowerCase())
          : true;

        const matchesPrice =
          (!this.minPrice || imovel.preco >= this.minPrice) &&
          (!this.maxPrice || imovel.preco <= this.maxPrice);

        const matchesServiceType = this.selectedServiceType
          ? imovel.tipoServico.toLowerCase().includes(this.selectedServiceType.toLowerCase())
          : true;

        return matchesCategory && matchesSearch && matchesPrice && matchesServiceType;
      });
    },

    formatPrice(value) {
      if (!value) return "0";
      return value
        .toLocaleString("pt-BR", { style: "currency", currency: "BRL" })
        .replace("R$", "")
        .trim();
    },

    selecionarImovel(imovel) {
      this.selectedImovelId = imovel.id;
      this.$router.push({
        name: "ViewOneImovel",
        query: { id: this.selectedImovelId },
      });
    },

    smoothScrollToSection() {
      const section = this.$refs.targetSection;
      const targetPosition = section.offsetTop;
      const startPosition = window.pageYOffset;
      const distance = targetPosition - startPosition;
      const duration = 1000;
      let start = null;

      const step = (timestamp) => {
        if (!start) start = timestamp;
        const progress = timestamp - start;
        const percentage = Math.min(progress / duration, 1);
        window.scrollTo(0, startPosition + distance * percentage);

        if (progress < duration) {
          window.requestAnimationFrame(step);
        }
      };

      window.requestAnimationFrame(step);
    },
  },
};
</script>

<style scoped>
html {
  scroll-behavior: smooth;
}

body {
  font-family: "Funnel Display", sans-serif;
}


.buttontosection {
  position: fixed;
  bottom: 20px;
  right: 20px;
  padding: 15px;
  font-size: 1.8rem;
  background-color: #fff;
  border: none;
  border-radius: 50%;
  cursor: pointer;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, background-color 0.3s ease;
}

.buttontosection:hover {
  transform: scale(1.1);
  background-color: #f0f0f0;
}

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
  font-family: "Funnel Display", sans-serif;
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

.Imovel__Container__box__images img {
  width: 500px;
  height: 300px;
  object-fit: cover;
}


.Imovel__Container__box__Right {
  flex: 2;
  max-width: 70%;
  padding: 2rem;
  background: #fff;
}

.Imovel__item__container {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

.Imovel__descricao {
  max-height: 17px;
  overflow: hidden;
}

.imovel__container__list {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 20px;
  padding: 0;
  padding-bottom: 20px;
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

.imovel__container__item:hover {
  cursor: pointer;
}

.Imovel__areasComuns {
  display: flex;
  gap: 20px;
}

.Ul__AreasComuns {
  display: flex;
  gap: 20px;
  list-style: none;
}

@media (min-width: 1024px) and (max-width: 1600px) {
  .imovel__container__item {
    width: 90%;
    max-width: 100%;
    max-height: 800px;
    height: auto;
    border: 5px solid #ededed;
    color: #000;
    border-radius: 10px;
    padding: 20px;
    list-style: none;
  }
  
}

@media (min-width: 768px) and (max-width: 1024px) {
  .Imovel__Container__box__images img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 7px;
  }

  .imovel__container__item {
    width: 90%;
    max-width: 100%;
    max-height: 800px;
    height: auto;
    border: 5px solid #ededed;
    color: #000;
    border-radius: 10px;
    padding: 20px;
    list-style: none;
  }


  .Imovel__areasComuns {
    display: flex;
    flex-direction: column;
  }

  .Ul__AreasComuns {
    display: flex;
    flex-direction: column;
    gap: 20px;
    list-style: none;
  }
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
  }

  .Imovel__Container__box__Left,
  .Imovel__Container__box__Right {
    max-width: 100%;
    flex: none;
  }

  .Imovel__Container__box__images img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 7px;
  }


  .imovel__container__item {
    width: 100%;
    padding: 15px;
  }

  .imovel__container__list {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 20px;
    padding: 0;
    padding-bottom: 20px;
    height: auto;
  }

  .imovel__container__item {
    width: 90%;
    max-width: 100%;
    max-height: 900px;
    height: auto;
    border: 5px solid #ededed;
    color: #000;
    border-radius: 10px;
    padding: 20px;
    list-style: none;
  }


  .Imovel__areasComuns {
    display: flex;
    flex-direction: column;
  }

  .Ul__AreasComuns {
    display: flex;
    flex-direction: column;
    gap: 20px;
    list-style: none;
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

  .imovel__container__list {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 20px;
    padding: 0;
    padding-bottom: 20px;
    height: auto;
  }

  .imovel__container__item {
    width: 90%;
    max-width: 100%;
    max-height: 1000px;
    height: auto;
    border: 5px solid #ededed;
    color: #000;
    border-radius: 10px;
    padding: 20px;
    list-style: none;
  }

  .Imovel__Container__box__images img {
    width: 100%;
    height: 300px;
    object-fit: cover;
    border-radius: 7px;
  }

  .Imovel__areasComuns {
    display: flex;
    flex-direction: column;
  }

  .Ul__AreasComuns {
    display: flex;
    flex-direction: column;
    gap: 20px;
    list-style: none;
  }

  .Imovel__descricao {
    display: none;
  }


}
</style>
