/********************************************************************************
 * Copyright (c) 2021, 2023 BMW Group AG
 * Copyright (c) 2021, 2023 Contributors to the Eclipse Foundation
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

using Org.Eclipse.TractusX.Portal.Backend.Offers.Library.Models;
using Org.Eclipse.TractusX.Portal.Backend.PortalBackend.DBAccess.Models;
using Org.Eclipse.TractusX.Portal.Backend.PortalBackend.PortalEntities.Enums;

namespace Org.Eclipse.TractusX.Portal.Backend.Offers.Library.Service;

/// <summary>
/// Business logic for handling offer-related operations. Includes persistence layer access.
/// </summary>
public interface IOfferSetupService
{ 
    /// <summary>
    /// Calls the external partner to autosetup the offer
    /// </summary>
    /// <param name="autoSetupData">The auto setup data</param>
    /// <param name="accessToken">the access token</param>
    /// <param name="autoSetupUrl">the autosetup url</param>
    /// <returns></returns>
    Task AutoSetupOfferSubscription(OfferThirdPartyAutoSetupData autoSetupData, string accessToken, string autoSetupUrl);  
    
    /// <summary>
    /// Internally auto setup the offer.
    /// </summary>
    /// <param name="data">The offer subscription id and url for the service</param>
    /// <param name="serviceAccountRoles">Roles that will be assigned to the service account</param>
    /// <param name="itAdminRoles">Roles that will be assigned to the company admin</param>
    /// <param name="iamUserId">Id of the iam user</param>
    /// <param name="offerTypeId">OfferTypeId of offer to be created</param>
    /// <param name="basePortalAddress">Address of the portal</param>
    /// <returns>Returns the response data</returns>
    Task<OfferAutoSetupResponseData> AutoSetupOfferAsync(OfferAutoSetupData data, IDictionary<string,IEnumerable<string>> serviceAccountRoles, IDictionary<string,IEnumerable<string>> itAdminRoles, string iamUserId, OfferTypeId offerTypeId, string basePortalAddress);
}