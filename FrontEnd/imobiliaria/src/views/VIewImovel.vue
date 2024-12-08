<template>
  <div ref="targetSection">
    <div class="container">
      <!-- Filtro de busca -->
      <div class="filter-container">
        <input type="text" id="searchBar" v-model="searchQuery" @input="filterImoveis"
          placeholder="Digite a cidade, bairro ou Rua..." class="filter-input" />
      </div>

      <!-- Filtro por tipo de imóvel -->
      <div class="filter-container">
        <select id="categoryFilter" v-model="selectedCategory" @change="filterImoveis" class="filter-select">
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
        <select id="serviceTypeFilter" v-model="selectedServiceType" @change="filterImoveis" class="filter-select">
          <option value="">Todos os serviços</option>
          <option value="Compra">Compra</option>
          <option value="Aluguel">Aluguel</option>
        </select>
      </div>

      <!-- Filtro por faixa de preço -->
      <div class="filter-container">
        <label for="priceFilter">Faixa de preço:</label>
        <input type="number" id="minPrice" v-model.number="minPrice" placeholder="Preço mínimo" class="filter-input"
          @input="filterImoveis" />
        <input type="number" id="maxPrice" v-model.number="maxPrice" placeholder="Preço máximo" class="filter-input"
          @input="filterImoveis" />
      </div>

      <div class="filter-container">
        <button @click="clearFilters" class="clear-filters-btn">Limpar filtros</button>
      </div>
    </div>

    <!-- Lista de imóveis -->
    <div class="Imovel__container">
      <ul class="imovel__container__list">
        <li v-for="Imovel in filteredImoveis" :key="Imovel.id" class="imovel__container__item"
          @click="selecionarImovel(Imovel)">
          <div class="Imovel__Container__internal__container">
            <div class="Imovel__Container__box__Left">
              <img v-if="Imovel.urLsImagens && Imovel.urLsImagens.length > 0" :src="Imovel.urLsImagens[0]"
                alt="Imagem do imóvel" class="imovel-image" />
            </div>
            <div class="Imovel__Container__box__Right">
              <div class="Imovel__item__container">
                <div class="Imove__item__container__item">
                  <div class="Imovel__preco">
                    <h2><strong>R$ {{ formatPrice(Imovel.preco) }}</strong></h2>
                  </div>

                  <div class="Imovel__TipoServico">
                    <p>{{ Imovel.tipoServico }}</p>
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
                <div class="Imovel__descricao">
                  <p>{{ Imovel.descricao }}</p>
                </div>

                <div class="Imove__item__container__item">
                  <div class="Imovel__box__rigth__buttons">

                    <button @click="openPopup2">Ligue</button>
                    <button @click="openPopup">Contatar</button>

                    <div v-if="isPopupVisible" class="popup">
                      <span @click="closePopup" class="close-btn">&times;</span>
                      <div class="contact-box">
                        <div class="internal__contact__box">
                          <h3>Contate o Anunciante</h3>
                          <form @submit.prevent="enviarMensagem" class="contact-form">
                            <div class="form-group">
                              <input type="email" id="email" v-model="email" placeholder="E-mail" required />
                            </div>
                            <div class="name__telefon__container">
                              <div class="form-group1">
                                <input type="text" id="nome" v-model="nome" placeholder="Nome" required />
                              </div>
                              <div class="form-group1">
                                <input type="text" id="telefone" v-model="telefone" placeholder="Telefone" required />
                              </div>
                            </div>
                            <div class="form-group">
                              <textarea id="mensagem" v-model="mensagem" placeholder="Mensagem" required></textarea>
                            </div>
                            <button type="submit" class="submit-btn">Contatar </button>
                            <p class="terms">Ao enviar, você está aceitando os <a href="#">Termos e Condições de uso</a>
                              e
                              as <a href="#">Políticas de Privacidade</a></p>
                          </form>
                        </div>
                      </div>
                    </div>

                    <div v-if="isPopupVisible" class="overlay" @click="closePopup"></div>
                  </div>
                </div>
              </div>


            </div>
          </div>
        </li>

      </ul>
    </div>

    <!-- Botão fixo de rolagem -->
    <button @click="smoothScrollToSection" class="buttontosection">
      <svg version="1.0" xmlns="http://www.w3.org/2000/svg" width="18px" height="18px"
        viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">

        <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000" stroke="none">
          <path d="M2505 5101 c-16 -10 -512 -502 -1102 -1092 -855 -857 -1072 -1080
-1078 -1106 -9 -44 18 -97 60 -117 29 -14 107 -16 624 -16 l591 0 0 -1335 c0
-1132 2 -1341 14 -1370 29 -69 -22 -66 962 -63 l886 3 29 33 29 32 0 1350 0
1350 591 0 c517 0 595 2 624 16 42 20 69 73 60 117 -6 26 -225 250 -1083 1109
-592 593 -1091 1085 -1108 1093 -42 20 -63 19 -99 -4z" />
        </g>
      </svg>
    </button>
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
      isPopupVisible: null
    };
  },

  mounted() {
    this.fetchImoveis();
  },

  methods: {
    // Função para limpar todos os filtros
    clearFilters() {
      this.searchQuery = "";
      this.selectedCategory = "";
      this.selectedServiceType = "";
      this.minPrice = null;
      this.maxPrice = null;
      this.filterImoveis();
    },
    openPopup() {
      this.isPopupVisible = true;
    },
    // Método para fechar o popup
    closePopup() {
      this.isPopupVisible = false;
    },
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

    selecionarImovel(imovel) {
      this.selectedImovelId = imovel.id;
      const tipoImovel = imovel.tipo.toLowerCase();

      if (tipoImovel === "casa") {
        this.$router.push({
          name: 'ViewOneImovelCasa',
          query: { id: this.selectedImovelId }
        });
      }
      else if (tipoImovel === "apartamento") {
        this.$router.push({
          name: 'ViewOneImovelApartamento',
          query: { id: this.selectedImovelId }
        });
      }
      else if (tipoImovel === "comercial") {
        this.$router.push({
          name: 'ViewOneImovelComercial',
          query: { id: this.selectedImovelId }
        });
      }
      else if (tipoImovel === "lote") {
        this.$router.push({
          name: 'ViewOneImovelLote',
          query: { id: this.selectedImovelId }
        });
      }
      else if (tipoImovel === "rural") {
        this.$router.push({
          name: 'ViewOneImoveRural',
          query: { id: this.selectedImovelId }
        });
      }
      else if (tipoImovel === "terreno") {
        this.$router.push({
          name: 'ViewOneImovelTerreno',
          query: { id: this.selectedImovelId }
        });
      }
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
  width: 60px;
  height: 60px;
  font-size: 1.8rem;
  background-color: #fff;
  border: none;
  border-radius: 50%;
  cursor: pointer;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, background-color 0.3s ease;
  border: 1px solid black;
}


.buttontosection:hover {
  transform: scale(1.1);
  background-color: #f0f0f0;
}

.container {
  display: flex;
  padding-inline: 3rem;
  margin: 20px;
  gap: 15px;
}

.filter-container {
  display: flex;
  gap: 10px;
}

.filter-input {
  width: 100%;
  height: 90%;
  padding: 12px;
  border-radius: 8px;
  border: 1px solid #7c98a7;
  font-size: 1rem;
}

.filter-select {
  width: 100%;
  height: 90%;
  padding: 0.90rem 1rem;
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
}

.Imovel__Container__box__Left {
  max-width: 30%;
  max-height: 100%;
  display: flex;
}

.Imovel__Container__box__Left img {
  width: 100%;
  max-width: 400px;
  height: 100%;
  max-height: 300px;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
}


.Imovel__Container__box__Right {
  flex: 2;
  max-width: 70%;
  padding: 1rem;
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
  width: 95%;
  max-width: 100%;
  max-height: 400px;
  height: auto;
  border: 2px solid #ededed;
  color: #000;
  border-radius: 10px;
  list-style: none;
  overflow: hidden;
}

.Imove__item__container__item p,
li {
  font-size: 13px;
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

.Imovel__box__rigth__buttons {
  width: 100%;
  height: auto;
  border-top: 2px solid #ededed;
  display: flex;
  justify-content: end;
  gap: 20px;
}


.Imovel__box__rigth__buttons button {
  margin-top: 10px;
  background-color: rgb(0, 43, 82);
  padding: 0.90rem 1rem;
  border-radius: 8px;
  border: none;
  color: #FFF;
  transition: .3S;
}

.Imovel__box__rigth__buttons button:hover {
  background-color: #1A5276;
  padding: 0.90rem 1rem;
  border-radius: 8px;
  border: none;
  transform: scale(1.1);
}

.Imovel__rua p {
  color: #1f1e1e;
  font-weight: 600;
  font-size: 18px;
}

.filter-container label {
  width: 70%;
  height: 90%;
  padding: 0.8rem;
  border-radius: 9px;
}

@media (min-width: 1024px) and (max-width: 1600px) {
  .imovel__container__item {
    width: 95%;
    max-width: 100%;
    max-height: 400px;
    height: auto;
    color: #000;
    border-radius: 10px;
    list-style: none;
  }

}

@media (min-width: 768px) and (max-width: 1024px) {
  .Imovel__Container__box__Left img {
    width: 100%;
    max-width: 400px;
    height: 100%;
    max-height: 400px;
    border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
  }


  .imovel__container__item {
    width: 95%;
    max-width: 100%;
    max-height: 800px;
    height: auto;
    color: #000;
    border-radius: 10px;
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

  .Imovel__Container__internal__container {
    flex-direction: column;
  }

  .Imovel__Container__box__Left,
  .Imovel__Container__box__Right {
    max-width: 100%;
    flex: none;
  }

  .Imovel__Container__box__Left img {
    width: 100%;
    max-width: 100%;
    height: 100%;
    max-height: 400px;
    border-radius: 10px;
  }


  .imovel__container__item {
    width: 100%;
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

  .Imovel__Container__box__Left img {
    width: 100%;
    max-width: 400px;
    height: 100%;
    max-height: 400px;
    border-radius: 10px;
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

/* Estilo para o popup */
.popup {
  display: block;
  position: fixed;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  padding: 20px;
  background-color: white;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
  z-index: 1000;
}

/* Estilo para o fundo escuro */
.overlay {
  position: fixed;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 500;
}

/* Botão de fechar */
.close-btn {
  position: absolute;
  top: 10px;
  right: 10px;
  cursor: pointer;
}


.contact-box {
  width: 30%;
  padding: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  position: fixed;
  top: 0;
  right: 0;
  height: 100vh;
  background-color: transparent;
  z-index: 1000;
  overflow-y: auto;
}

.internal__contact__box {
  width: 100%;
  text-align: left;
  padding: 20px;
  border: 3px solid #d4d4d4;
  border-radius: 9px;
}

.internal__contact__box p {
  font-weight: 600;
  font-size: 14px;
}

input[type="email"],
input[type="text"],
textarea {
  width: 100%;
  height: 90%;
  padding: 0.8rem;
  border: 3px solid #ededed;
  border-radius: 9px;
  margin-bottom: 10px;
}

.name__telefon__container {
  display: flex;
  width: 100%;
  gap: 10px;
}

.form-group1 {
  width: 50%;
}

.submit-btn {
  width: 100%;
  padding: 1rem;
  border-radius: 9px;
  border: 3px solid #ededed;
  color: #000;
  font-weight: 600;
  font-family: "Funnel Display", sans-serif;
}

.submit-btn:hover {
  cursor: pointer;
}

.terms {
  font-size: 12px;
  margin-top: 10px;
}

.terms a {
  color: #3498db;
  text-decoration: none;
}

.terms a:hover {
  text-decoration: underline;
}

.clear-filters-btn {
  padding: 10px 20px;
  background-color: #ff4c4c;
  /* Cor de fundo */
  color: #ffffff;
  /* Cor do texto */
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  font-weight: bold;
  transition: background-color 0.3s, transform 0.3s;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.clear-filters-btn:hover {
  background-color: #e04343;
  transform: translateY(-2px);
}
</style>
