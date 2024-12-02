<template>
    <div class="property-inputs">
        <div class="counter-group">
            <div v-for="(item, index) in counters" :key="index" class="counter"> <label>{{ item.label }}</label>
                <div class="counter-controls"> <button @click="decrement(index)" :disabled="item.value <= 0">-</button>
                    <input type="number" :value="item.value" readonly /> <button @click="increment(index)">+</button>
                </div>
            </div>
        </div>
        <div class="area-group">
            <div v-for="(area, index) in areas" :key="index" class="area-input"> <label>{{ area.label }}</label>
                <div class="input-wrapper"> <input type="number" v-model="area.value" /> <span>m²</span> </div>
            </div>
        </div>
    </div>
</template>
<script>export default {
    data() {
        return
        {
            counters: [{ label: "Quartos (opcional)", value: 0 }, { label: "Banheiros (opcional)", value: 0 }, { label: "Suítes (opcional)", value: 0 }, { label: "Garagens (opcional)", value: 0 },], areas: [{ label: "Área útil", value: 0 }, { label: "Área total", value: 0 },], };
    }, methods: { increment(index) { this.counters[index].value++; }, decrement(index) { if (this.counters[index].value > 0) { this.counters[index].value--; } }, },
}; </script>
<style scoped>
.property-inputs {
    display: flex;
    flex-direction: column;
    gap: 2rem;
}

.counter-group,
.area-group {
    display: flex;
    flex-wrap: wrap;
    gap: 1.5rem;
}

.counter,
.area-input {
    display: flex;
    flex-direction: column;
    width: 200px;
}

.counter-controls {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

button {
    width: 30px;
    height: 30px;
    font-size: 1rem;
    cursor: pointer;
}

input[type="number"] {
    width: 60px;
    text-align: center;
}

.input-wrapper {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

span {
    font-size: 1rem;
}
</style>
