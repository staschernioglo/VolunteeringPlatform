export interface GoodDeedForCreateDto {
    name: string;
    category: string;
    description?: string;
    date?: Date;
    locality?: string;
    address?: string;
    phoneNumber?: string;
    requiredNumberOfvolunteers?: number;
    image?: File;
}

export const goodDeedcategories = ['Intellectual Assistance', 'Education', 'Physical Assistance',
 'Financial Assistance', 'Social Assistance', 'Other'];