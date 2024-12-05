<template>
  <div class="Alpha__Container">
    <div class="Alpha__internal__Container">
      <div class="Container__tittle">
        <h1>Ouça de nossos clientes</h1>
      </div>

      <div class="Alpha__internal__Container__2">
        <section class="Alpha__left">
          <div class="person__info">
            <div class="personal">
              <img src="@/Images/1.png" alt="Joana Rockefeller" class="profile-pic">
              <h2>Joana Rockefeller</h2>
            </div>
            <hr class="name__underline">
            <p class="location">Dublin, Irlanda</p>
          </div>
          <p class="quote">
            "A experiência com esta imobiliária foi impecável. Os detalhes fornecidos sobre cada imóvel são precisos e
            muito úteis, tornando a escolha do lar ideal simples e agradável. Fiquei particularmente encantada com o
            atendimento ao cliente, que transformou cada etapa do processo em algo especial."
          </p>
        </section>

        <section class="Alpha__right">
          <div class="person__info">
            <div class="personal">
              <img src="@/Images/1.png" alt="Andrew Carnegie" class="profile-pic">
              <h2>Andrew Carnegie</h2>
            </div>
            <hr class="name__underline">
            <p class="location">Edimburgo, Escócia</p>
          </div>
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
  name: 'Alpha'
}
</script>

<style scoped>
.Alpha__Container {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Alpha__internal__Container {
  margin-top: 100px;
  width: 100%;
  font-family: "Funnel Display", sans-serif;
  text-align: center;
}

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

.Alpha__internal__Container__2 {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  padding: 20px;
}

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

.profile-pic {
  width: 40px;
  height: 40px;
  border-radius: 50%;
}

.name__underline {
  border: 0;
  border-bottom: 2px solid #000;
  margin: 5px 0;
}

.location {
  font-style: italic;
  color: #555;
}

.quote {
  line-height: 1.6;
  color: #333;
  text-align: justify;
}

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