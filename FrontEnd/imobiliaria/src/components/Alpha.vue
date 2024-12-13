<template>
  <!-- Container principal do componente -->
  <div class="Alpha__Container">
    <!-- Container interno para organizar os elementos -->
    <div class="Alpha__internal__Container">
      <!-- Título da seção -->
      <div class="Container__tittle">
        <h1>Ouça de nossos clientes</h1>
      </div>

      <!-- Container com os depoimentos -->
      <div class="Alpha__internal__Container__2">
        <!-- Depoimento do lado esquerdo -->
        <section class="Alpha__left">
          <div class="person__info">
            <div class="personal">
              <!-- Nome da pessoa -->
              <h2>Joana Rockefeller</h2>
            </div>
            <!-- Linha sublinhando o nome -->
            <hr class="name__underline">
            <!-- Localização da pessoa -->
            <p class="location">Dublin, Irlanda</p>
          </div>
          <!-- Depoimento da pessoa -->
          <p class="quote">
            "A experiência com esta imobiliária foi impecável. Os detalhes fornecidos sobre cada imóvel são precisos e
            muito úteis, tornando a escolha do lar ideal simples e agradável. Fiquei particularmente encantada com o
            atendimento ao cliente, que transformou cada etapa do processo em algo especial."
          </p>
        </section>

        <!-- Depoimento do lado direito -->
        <section class="Alpha__right">
          <div class="person__info">
            <div class="personal">
              <!-- Nome da pessoa -->
              <h2>Andrew Carnegie</h2>
            </div>
            <!-- Linha sublinhando o nome -->
            <hr class="name__underline">
            <!-- Localização da pessoa -->
            <p class="location">Edimburgo, Escócia</p>
          </div>
          <!-- Depoimento da pessoa -->
          <p class="quote">
            "Depois de conhecer a Imobiliária e explorar algumas das opções oferecidas, posso dizer
            com confiança que foi uma experiência excepcional. A variedade de imóveis disponíveis é impressionante —
            desde apartamentos modernos a casas clássicas, cada visita revelou algo único e encantador."
          </p>
        </section>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  // Nome do componente para identificar no projeto
  name: 'Alpha'
}
</script>

<style scoped>
/* Estilos do container principal */
.Alpha__Container {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

/* Estilos do container interno */
.Alpha__internal__Container {
  margin-top: 100px;
  width: 100%;
  font-family: "Funnel Display", sans-serif;
  text-align: center;
}

/* Estilo do título */
.Container__tittle {
  width: 100%;
  height: 100px;
  background-color: rgb(0, 43, 82);
  display: flex;
  align-items: center;
  justify-content: center;
  color: #FFF;
}

.Alpha__internal__Container h1 {
  font-size: 2.5rem;
}

/* Container que organiza os depoimentos */
.Alpha__internal__Container__2 {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  padding: 20px;
}

/* Estilos para os depoimentos */
.Alpha__left,
.Alpha__right {
  width: 45%;
  margin-bottom: 20px;
}

.person__info {
  margin-bottom: 15px;
}

.personal {
  display: flex;
  align-items: center;
  gap: 10px;
}

/* Linha de sublinhado para o nome */
.name__underline {
  border: 0;
  border-bottom: 2px solid #000;
  margin: 5px 0;
}

/* Estilo da localização */
.location {
  font-style: italic;
  color: #555;
}

/* Estilo do texto dos depoimentos */
.quote {
  line-height: 1.6;
  color: #333;
  text-align: justify;
}

/* Estilos responsivos */
@media (max-width: 800px) {
  .Alpha__internal__Container h1 {
    font-size: 2rem;
  }

  .Alpha__left,
  .Alpha__right {
    width: 100%;
  }
}

@media (max-width: 400px) {
  .Alpha__internal__Container h1 {
    font-size: 1.5rem;
  }

  .quote {
    font-size: 14px;
  }
}
</style>
