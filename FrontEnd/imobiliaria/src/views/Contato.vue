<template>
  <div class="container">
    <h1 class="heading">Entre em Contato Conosco</h1>
    <div class="internal__Container">
      <div class="Container__person">
        <div class="avatar-wrapper">
          <img src="/src/Images/Fred.png" alt="" class="person__img">
        </div>
        <p class="person__Name">Fred</p>
        <p class="person__Number">+55 (31) 98242-4359</p>
        <p><button class="person__Contact__btn">WhatsApp</button></p>
      </div>
      <div class="Container__person">
        <div class="avatar-wrapper">
          <img src="/src/Images/Guilherme.png" alt="" class="person__img">
        </div>
        <p class="person__Name">Guilherme</p>
        <p class="person__Number">+55 (31) 98242-4359</p>
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
.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;
  padding: 3rem;
  background: linear-gradient(135deg, #f3f4f7, #eceff1);
  min-height: 50vh;
  text-align: center;
  position: relative;
}

.heading {
  font-family: "Funnel Display", sans-serif;
  font-size: 2.5rem;
  color: #333;
  margin-bottom: 2rem;
  animation: fadeInDown 1s ease-out;
}

.internal__Container {
  display: flex;
  flex-wrap: wrap;
  gap: 2rem;
  justify-content: center;
}

.Container__person {
  background-color: #fff;
  border-radius: 15px;
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
  width: 250px;
  transform: scale(0.98);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.Container__person:hover {
  transform: scale(1);
  box-shadow: 0 12px 24px rgba(0, 0, 0, 0.1);
}

.avatar-wrapper {
  background: radial-gradient(circle, #e3e8ee, #fff);
  padding: 8px;
  border-radius: 50%;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  margin-bottom: 1rem;
}

.person__img {
  border-radius: 50%;
  width: 100px;
  height: 100px;
  object-fit: cover;
}

.person__Name {
  font-size: 1.2rem;
  font-weight: 600;
  color: #333;
  margin: 0.5rem 0;
}

.person__Number {
  font-size: 1rem;
  color: #555;
  margin-bottom: 1rem;
}

.person__Contact__btn {
  padding: 0.8rem 1.5rem;
  border: none;
  border-radius: 50px;
  background-color: #25D366;
  color: #fff;
  font-weight: bold;
  font-size: 1rem;
  cursor: pointer;
  transition: all 0.3s ease;
}

.person__Contact__btn:hover {
  background-color: #128C7E;
  transform: translateY(-2px);
}

@keyframes fadeInDown {
  from {
    opacity: 0;
    transform: translateY(-50px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

@media (max-width: 768px) {
  .internal__Container {
    gap: 1.5rem;
  }

  .Container__person {
    width: 200px;
  }
}

@media (max-width: 480px) {
  .heading {
    font-size: 1.8rem;
  }

  .person__Contact__btn {
    padding: 0.6rem 1.2rem;
    font-size: 0.9rem;
  }
}
</style>
