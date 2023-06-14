Vue.createApp({
    data() {
        return {
            baseUrl: "http://localhost:5053/api/items",
            items: [],
            foundItem: {},
            addItemData: {id: 0, name: "", price: 0, description: 0},
            updateItem: {id: 0, name: "", price: 0, description: 0},
            deleteItem: {id: 0, name: "", price: 0, description: 0},
            Id: 0,
            idToFind: 0,
            idToDelete: 0,
            Description: 0,
            idItem: {},
            Name: "",
            Price: 0,
        }
    },
    async created() {
    await this.getAllItems();
  },
  methods: {
    async getAllItems() {
      try {
        const response = await axios.get(this.baseUrl);
        this.items = await response.data;
      } catch (ex) {
        alert(ex.message);
      }
    },
    async getById() {
        try {
            const response = await axios.get(this.baseUrl + "/" + this.idToFind);
            this.foundItem = await response.data;
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    async add() {
        try {
            response = await axios.post(this.baseUrl, this.addItemData)
            this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    async update() {
        try {
        response = await axios.put(this.baseUrl, this.updateItem)
        this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    async delete() {
        try {
        response = await axios.delete(this.baseUrl, this.deleteItem + "/" + this.idToDelete)
        this.getAllItems()
        }
        catch (ex) {
            alert(ex.message)
        }
    },
    //Sort by string
    sortString() {
        this.items.sort((item1, item2) => item1.name.localeCompare(item2.name))
    },
    //sort by ints
    sortInt() {
        this.items.sort((item1, item2) => item1.description - item2.description)
    },
}
    
}).mount("#app")