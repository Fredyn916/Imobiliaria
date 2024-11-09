<template>
  <div>
    <header class="Nav__header">
      <nav class="NavBar">
        <MenusNav />
        <ul class="Nav__actions">
          <li class="li__Home">
            <RouterLink to="/" class="Anunce__Bnt">Anunciar Gratis</RouterLink>
            <RouterLink to="/" class="Entry__Bnt">Entrar</RouterLink>
          </li>
        </ul>
      </nav>
    </header>

    <RouterView />
    <section class="Hero__bg">
      <div class="Hero__bg__container">
        <div class="Hero__bg__Tittle">
          Você muda, sua vida muda
        </div>

        <div class="Hero__bg__container__box1">
          <button class="Hero__bg__container__box1__btn">Alugar</button>
          <button class="Hero__bg__container__box1__btn">Comprar</button>
          <button class="Hero__bg__container__box1__btn" id="btn3">Imovel Novo</button>
        </div>

        <div class="Hero__bg__container__box2">
          <div class="Hero__bg__container__box2__label">
            <select id="opcoes" name="opcoes">
              <option disabled value="">Casa</option>
              <option value="opcao1">Casa (Todos)</option>
              <option value="opcao2">Casa em condominio</option>
              <option disabled value="opcao3">Apartamento</option>
              <option value="opcao4">Apartamento (Todos)</option>
              <option value="opcao5">Cobertura</option>
              <option value="opcao6">Flat</option>
              <option value="opcao7">Garden</option>
              <option disabled value="opcao8">Lote</option>
              <option value="opcao9">Lote (Todos)</option>
              <option value="opcao10">Lote em condominio</option>
              <option disabled value="opcao11">Comercial</option>
              <option value="opcao12">Comercial (Todos)</option>
              <option value="opcao13">Sala-Andar</option>
              <option value="opcao14">Loja</option>
              <option value="opcao15">Galpão</option>
              <option value="opcao16">Vaga de Garagem</option>
              <option value="opcao17">Predio</option>
              <option disabled value="opcao18">Rural</option>
              <option value="opcao19">Rural (Todos)</option>
              <option disabled value="opcao20">Terreno/Lote</option>
              <option value="opcao21">Chácara</option>
              <option value="opcao22">Fazenda</option>
            </select>
          </div>

          <div class="Hero__bg__container__box2__item1">
            <input type="search" id="pesquisa" name="pesquisa"
              placeholder="Digite cidades bairros ou caracteristicas para pesquisar...">
          </div>

          <div class="Hero__bg__container__box2__item2">
            <button class="Hero__bg__container__box2__Search__Bnt">Buscar</button>
          </div>

        </div>
      </div>
    </section>

    <section class="all">
    </section>
  </div>
</template>

<script>
import MenusNav from './components/MenusNav.vue';

export default {
  name: 'App',
  components: {
    MenusNav
  },
  mounted() {
    const buttons = document.querySelectorAll('.Hero__bg__container__box1__btn');

    buttons.forEach(button => {
      button.addEventListener('click', () => {
        buttons.forEach(btn => btn.classList.remove('active'));
        button.classList.add('active');
      });
    });
  }
};
</script>


<style scoped>
a {
  text-decoration: none;
}

.Nav__header {
  margin: 0;
  padding: 0;
}

.NavBar {
  display: flex;
  justify-content: space-between;
  padding: 15px 15px;
  align-items: center;
  height: 60px;
  max-width: 100%;
  margin: 0 auto;
  width: 100%;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}


.Nav__actions {
  display: flex;
  gap: 20px;
  list-style: none;
  padding: 0;
  margin: 0;
}

.li__Home {
  display: flex;
  gap: 20px;
}

.Anunce__Bnt {
  background-color: transparent;
  border: none;
  color: black;
  padding: 0.90rem 1.5rem;
  text-align: center;
  text-decoration: none;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Anunce__Bnt:hover {
  background-color: #505050;
  color: #FFF;
}

.Entry__Bnt {
  background-color: #8CB9C5;
  border: none;
  color: white;
  padding: 0.90rem 1.5rem;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Entry__Bnt:hover {
  background-color: #59808b;
}

.Hero__bg {
  width: 100%;
  height: 450px;
  background: url('@/Images/bg.png');
  background-repeat: no-repeat;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg__container {
  text-align: center;
  width: 1000px;
  max-width: 1200px;
}

.Hero__bg__Tittle {
  font-size: 3rem;
  color: white;
}

.Hero__bg__container__box1 {
  background-color: #FFF;
  width: 350px;
  height: 70px;
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  display: flex;
  align-items: center;
  justify-content: space-around;
  margin-top: 50px;
}

.Hero__bg__container__box1__btn {
  width: 30%;
  height: 50px;
  background-color: #FFF;
  color: black;
  font-size: 16px;
  font-weight: bold;
  border: none;
  border-radius: 15px;
  cursor: pointer;
  text-align: center;
  display: inline-block;
  position: relative;
  transition: background-color 0.3s ease, transform 0.2s ease;
  line-height: 50px;
}

.Hero__bg__container__box1__btn:after {
  content: "";
  position: absolute;
  bottom: 5px;
  left: 0;
  width: 0%;
  height: 2px;
  background-color: black;
  transition: width 0.3s ease;
}

.Hero__bg__container__box1__btn.active {
  background-color: #f3f7f8;
  transform: scale(1);
}

.Hero__bg__container__box1__btn.active:after {
  align-items: center;
  width: 100%;
}

.Hero__bg__container__box1__btn:not(.active) {
  transition: background-color 0.3s ease;
}




.Hero__bg__container__box2 {
  background-color: #FFF;
  width: 100%;
  height: 80px;
  border-top-right-radius: 15px;
  border-bottom-left-radius: 15px;
  border-bottom-right-radius: 15px;
  display: flex;
  justify-content: space-around;
}

.Hero__bg__container__box2__label {
  width: 20%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg__container__box2__item1 {
  width: 60%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg__container__box2__item2 {
  width: 15%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg__container__box2__label select {
  width: 100%;
  height: 50px;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 10px;
  font-size: 16px;
  cursor: pointer;
  overflow-y: auto;
  background-color: #f9f9f9;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
}

option:disabled {
  color: #888;
  font-style: italic;
}

.Hero__bg__container__box2__label select:focus {
  border-color: #007BFF;
  box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
}


input[type="search"] {
  width: 100%;
  height: 50px;
  padding: 10px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 10px;
  outline: none;
  transition: border-color 0.3s;
}

input[type="search"]:focus {
  border-color: #007BFF;
  box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
}

.Hero__bg__container__box2__Search__Bnt {
  background-color: #8CB9C5;
  border: none;
  color: white;
  padding: 1.2rem 3em;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 12px;
  cursor: pointer;
  border-radius: 10px;
  transition: background-color 0.3s;
}

.Hero__bg__container__box2__Search__Bnt:hover {
  background-color: #59808b;
}

.all {
  background-color: black;
  width: 100%;
  height: 1000px;
}
</style>
