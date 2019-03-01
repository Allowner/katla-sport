export class HiveSectionProductListItem {
    constructor(
        public id: number,
        public productId: number,
        public quantity: number,
        public isDeleted: boolean,
        public isDelivered: boolean,
        public hiveSectionId: number
    ) { }
}