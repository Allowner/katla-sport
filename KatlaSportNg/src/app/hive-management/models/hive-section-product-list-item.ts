export class HiveSectionProductListItem {
    constructor(
        public id: number,
        public code: string,
        public name: string,
        public amount: number,
        public isDeleted: boolean,
        public storeHiveSectionId: number
    ) { }
}