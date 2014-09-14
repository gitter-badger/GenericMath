﻿//  *************************************************************
// <copyright file="IVectorRoom.cs" company="${Company}">
//     Copyright (c)  2014 andy. All rights reserved.
// </copyright>
// <author> andy</author>
// <email>andreas.augustinba@gmx.de</email>
// *************************************************************
//   1.0.0  31 / 8 / 2014 Created the Class
// *************************************************************

namespace Math.Base
{
    public interface IVectorRoom<TF, TField, TG, TGroup> : IModule<TF, TField, TG, TGroup>
        where TField : IField<TF>
        where TGroup : IGroup<TG>
    {
    }
}