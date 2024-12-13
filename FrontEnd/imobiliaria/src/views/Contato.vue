<template>
  <div class="container">
    <h1 class="heading">Entre em Contato Conosco</h1>
    <div class="internal__Container">
      <div class="Container__person">
        <div class="avatar__wrapper">
          <img src="/src/Images/Fred.png" alt="" class="person__img">
        </div>
        <p class="person__Name">Fred</p>
        <p class="person__Number">+55 (31) 99446-8205</p>
        <p><button class="person__Contact__btn">WhatsApp</button></p>
      </div>
      <div class="Container__person">
        <div class="avatar__wrapper">
          <img src="/src/Images/Guilherme.png" alt="" class="person__img">
        </div>
        <p class="person__Name">Guilherme</p>
        <p class="person__Number">+55 (31) 97578-2180</p>
        <p><button class="person__Contact__btn">WhatsApp</button></p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Contato'
}
</script>

<style scoped>
/* Container principal da página */
.container {
  display: flex;
  /* Usando flexbox para layout */
  flex-direction: column;
  /* Organiza os itens em coluna */
  align-items: center;
  /* Alinha os itens ao centro horizontalmente */
  justify-content: space-around;
  /* Espaça igualmente os itens dentro do container */
  padding: 3rem;
  /* Espaçamento interno de 3rem */
  background-color: #FFF;
  /* Cor de fundo branca */
  min-height: 50vh;
  /* Altura mínima de 50% da altura da tela */
  text-align: center;
  /* Alinha o texto ao centro */
  position: relative;
  /* Define o contexto de posicionamento para elementos filhos */
}

/* Título principal */
.heading {
  font-family: "Funnel Display", sans-serif;
  /* Fonte personalizada */
  font-size: 2.5rem;
  /* Tamanho da fonte */
  color: #333;
  /* Cor do texto */
  margin-bottom: 2rem;
  /* Espaçamento abaixo do título */
  animation: fadeInDown 1s ease-out;
  /* Animação de entrada com efeito de deslizamento para baixo */
}

/* Container interno que envolve as pessoas */
.internal__Container {
  display: flex;
  /* Usando flexbox para layout */
  flex-wrap: wrap;
  /* Permite que os itens quebrem linha quando necessário */
  gap: 2rem;
  /* Espaçamento entre os itens */
  justify-content: center;
  /* Centraliza os itens horizontalmente */
}

/* Container individual para cada pessoa */
.Container__person {
  background-color: #fff;
  /* Cor de fundo branca */
  border-radius: 15px;
  /* Bordas arredondadas */
  display: flex;
  /* Usando flexbox para layout */
  flex-direction: column;
  /* Organiza os itens em coluna */
  align-items: center;
  /* Alinha os itens ao centro */
  padding: 2rem;
  /* Espaçamento interno de 2rem */
  width: 250px;
  /* Largura fixa de 250px */
  transform: scale(0.98);
  /* Inicialmente, reduz o tamanho da pessoa */
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  /* Transições suaves para transformação e sombra */
}

/* Efeito de hover no container da pessoa */
.Container__person:hover {
  cursor: pointer;
  /* Muda o cursor para um ponteiro ao passar o mouse */
  transform: scale(1);
  /* Aumenta para o tamanho original */
  box-shadow: 0 12px 24px rgba(0, 0, 0, 0.1);
  /* Adiciona uma sombra suave ao passar o mouse */
}

/* Wrapper para o avatar da pessoa */
.avatar__wrapper {
  padding: 8px;
  /* Espaçamento interno de 8px */
  border-radius: 50%;
  /* Torna o wrapper circular */
  margin-bottom: 1rem;
  /* Espaçamento abaixo do avatar */
}

/* Imagem do avatar da pessoa */
.person__img {
  border-radius: 50%;
  /* Torna a imagem circular */
  width: 100px;
  /* Largura de 100px */
  height: 100px;
  /* Altura de 100px */
  object-fit: cover;
  /* Ajusta a imagem para cobrir o container sem distorção */
}

/* Nome da pessoa */
.person__Name {
  font-size: 1.2rem;
  /* Tamanho da fonte */
  font-weight: 600;
  /* Peso da fonte em negrito */
  color: #333;
  /* Cor do texto */
  margin: 0.5rem 0;
  /* Espaçamento vertical de 0.5rem */
}

/* Número de contato da pessoa */
.person__Number {
  font-size: 1rem;
  /* Tamanho da fonte */
  color: #555;
  /* Cor do texto */
  margin-bottom: 1rem;
  /* Espaçamento abaixo do número */
}

/* Botão de contato */
.person__Contact__btn {
  padding: 0.8rem 1.5rem;
  /* Padding de 0.8rem vertical e 1.5rem horizontal */
  border: none;
  /* Sem borda */
  border-radius: 50px;
  /* Bordas arredondadas */
  background-color: #25D366;
  /* Cor de fundo verde do WhatsApp */
  color: #fff;
  /* Cor do texto branca */
  font-weight: bold;
  /* Peso da fonte em negrito */
  font-size: 1rem;
  /* Tamanho da fonte */
  cursor: pointer;
  /* Cursor de ponteiro ao passar o mouse */
  transition: all 0.3s ease;
  /* Transição suave para todos os efeitos */
}

/* Efeito de hover no botão de contato */
.person__Contact__btn:hover {
  background-color: #128C7E;
  /* Cor de fundo mais escura ao passar o mouse */
  transform: translateY(-2px);
  /* Leve deslocamento para cima */
}

/* Animação de deslizamento para o título */
@keyframes fadeInDown {
  from {
    opacity: 0;
    /* Começa invisível */
    transform: translateY(-50px);
    /* Começa deslocado para cima */
  }

  to {
    opacity: 1;
    /* Torna-se totalmente visível */
    transform: translateY(0);
    /* Retorna à posição original */
  }
}

/* Estilos responsivos para telas menores */
@media (max-width: 768px) {
  .internal__Container {
    gap: 1.5rem;
    /* Diminui o espaço entre os itens */
  }

  .Container__person {
    width: 200px;
    /* Diminui a largura dos containers para 200px */
  }
}

/* Estilos responsivos para telas ainda menores */
@media (max-width: 480px) {
  .heading {
    font-size: 1.8rem;
    /* Diminui o tamanho do título */
  }

  .person__Contact__btn {
    padding: 0.6rem 1.2rem;
    /* Diminui o padding do botão */
    font-size: 0.9rem;
    /* Diminui o tamanho da fonte do botão */
  }
}
</style>
